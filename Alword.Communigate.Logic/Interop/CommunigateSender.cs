using Alword.Communigate.Logic.Command;
using Alword.Communigate.Logic.Config;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace Alword.Communigate.Logic.Interop
{
	public interface ICommunigateClient
	{
		/// <summary>
		/// Клиент должен выполнить операцию login для того, чтобы аутентифицироваться и создать сессию XIMSS.
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		public Task<Session> LoginAsync(Login login);

		/// <summary>
		/// Запрашивает список папок
		/// </summary>
		/// <param name="mailboxList"></param>
		/// <returns></returns>
		public Task<Mailbox[]> MailboxList(MailboxList mailboxList);
		public Task<Mailbox[]> MailboxSync(MailboxSync mailboxList);
	}
	public partial class CommunigateSender : ICommunigateClient
	{
		private readonly ICommunigateExchange _exchange;
		private readonly CommunigateReceiver _receiver;
		private readonly IOptions<CommunigateConfig> _options;
		public CommunigateSender(IOptions<CommunigateConfig> options)
		{
			_options = options;
			_exchange = new CommunigateExchange(_options.Value.Host, _options.Value.Port);
			_receiver = new CommunigateReceiver();
			_exchange.Bind(_receiver);
			_exchange.StartConnection();
		}

		private async Task<XDocument[]> RequestHandler<T>(T command) where T : BaseCommand, new()
		{
			var callback = new CallbackEvent(command.Id);
			_receiver.AddCallback(callback);
			await _exchange.Send(command);
			while (!callback.IsComplete) await Task.Yield();
			return callback.Messages.ToArray();
		}
	}
}
