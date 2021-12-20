using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	/// <summary>
	/// Клиент должен выполнить операцию login для того, чтобы аутентифицироваться и создать сессию XIMSS.
	/// </summary>
	[XmlRoot("login")]
	public class Login : BaseCommand
	{
		[XmlAttribute("authData")]
		public string AuthData { get; set; } = string.Empty;
		[XmlAttribute("password")]
		public string Password { get; set; } = string.Empty;
	}
}
