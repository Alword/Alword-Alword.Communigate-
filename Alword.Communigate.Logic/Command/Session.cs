using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	[XmlRoot("session")]
	public class Session : BaseCommand
	{
		[XmlAttribute("urlID")]
		public string UrlID { get; set; } = string.Empty;
		[XmlAttribute("userName")]
		public string UserName { get; set; } = string.Empty;
		[XmlAttribute("realName")]
		public string RealName { get; set; } = string.Empty;
		[XmlAttribute("Version")]
		public string Version { get; set; } = string.Empty;
	}
}
