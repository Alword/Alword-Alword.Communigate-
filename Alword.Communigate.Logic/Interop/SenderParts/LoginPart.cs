using Alword.Communigate.Logic.Command;
using Alword.Communigate.Logic.Utils;

namespace Alword.Communigate.Logic.Interop
{
	public partial class CommunigateSender
	{
		public async Task<Session> LoginAsync(Login login)
		{
			var responses = await RequestHandler(login);
			if (responses.Length != 1) throw new InvalidOperationException($"Ошибка авторизации");
			var session = responses[0];
			var name = session.Root?.Name.LocalName ?? "";
			if (!name.Equals(nameof(Session), StringComparison.InvariantCultureIgnoreCase))
				throw new InvalidOperationException($"Неожиданный ответ {name}");
			var response = Xmls.As<Session>(session);
			return response;
		}
	}
}
