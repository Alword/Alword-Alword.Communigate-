using System.Xml.Linq;

namespace Alword.Communigate.Logic.Interop
{
	public class CallbackEvent
	{
		public string Id { get; }
		public bool IsComplete { get; private set; } = false;
		public List<XDocument> Messages { get; }
		public CallbackEvent(string id)
		{
			Id = id;
			Messages = new List<XDocument>();
		}
		public void AppendMessage(XDocument document) => Messages.Add(document);
		public void Complete() => IsComplete = true;
	}
}
