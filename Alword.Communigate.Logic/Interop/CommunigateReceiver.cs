using Alword.Communigate.Logic.Command;
using System.Xml.Linq;

namespace Alword.Communigate.Logic.Interop
{
	public class CommunigateReceiver : BaseCommunigateReceiver
	{
		private readonly Dictionary<string, CallbackEvent> _commandsDictionary = new();
		public void AddCallback(CallbackEvent callbackEvent)
			=> _commandsDictionary.Add(callbackEvent.Id, callbackEvent);
		protected override void Receive(string nodeName, string message)
		{
			var document = XDocument.Parse(message);
			var id = document.Root?.FirstAttribute?.Value ?? "";
			var readEvent = _commandsDictionary.TryGetValue(id, out var callbackEvent);
			if (!readEvent || callbackEvent is null) return;

			var documentName = document?.Root?.Name.LocalName ?? "";

			var isDocumentResponse = documentName.Equals(nameof(Response), StringComparison.InvariantCultureIgnoreCase) is true;
			// test
			if (isDocumentResponse)
			{
				callbackEvent.Complete();
				_commandsDictionary.Remove(id);
			}
			else if (document is not null)
			{
				callbackEvent.AppendMessage(document);
			}
		}
	}
}
