using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	/// <summary>Эти синхронные сообщения с данными отправляются, когда Сервер обрабатывает запрос mailboxList.</summary>
	[XmlRoot("mailbox")]
	public class Mailbox
	{
		/// <summary>имя Папки в кодировке UTF-8.</summary>
		[XmlAttribute("mailbox")] public string Name { get; set; } = string.Empty;
		/// <summary></summary>
		[XmlAttribute("BoxSeq")] public string BoxSeq { get; set; } = string.Empty;
		[XmlAttribute("Messages")] public string Messages { get; set; } = string.Empty;
		[XmlAttribute("Size")] public string Size { get; set; } = string.Empty;
		[XmlAttribute("UIDNext")] public string UIDNext { get; set; } = string.Empty;
		/// <summary>стандартные и расширенные атрибуты IMAP для Папок</summary>
		[XmlAttribute("UIDValidity")] public string UIDValidity { get; set; } = string.Empty;
		[XmlAttribute("Unseen")] public string Unseen { get; set; } = string.Empty;
	}
}
