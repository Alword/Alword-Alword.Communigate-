using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	public class BaseCommand
	{
		[XmlAttribute("id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}
