using Alword.Communigate.Logic.Command;
using Alword.Communigate.Logic.Utils;

namespace Alword.Communigate.Logic.Interop
{
	public partial class CommunigateSender
	{
		public async Task<Mailbox[]> MailboxList(MailboxList list)
		{
			var responses = await RequestHandler(list);
			List<Mailbox> mailboxes = new(responses.Length);
			foreach (var response in responses)
			{
				var box = Xmls.As<Mailbox>(response);
				mailboxes.Add(box);
			}
			var result = mailboxes.ToArray();
			return result;
		}
	}
}
