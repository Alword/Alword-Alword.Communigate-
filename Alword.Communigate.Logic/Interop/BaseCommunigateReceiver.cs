using System.Xml.Linq;

namespace Alword.Communigate.Logic.Interop
{
	public class BaseCommunigateReceiver : ICommunigateReceiver
	{
		public void Receive(string message)
		{
			var document = XDocument.Parse(message);
			var nodeName = document.Root!.Name.LocalName;
			Receive(nodeName, message);
		}
		protected virtual void Receive(string nodeName, string message) { return; }
	}
}
