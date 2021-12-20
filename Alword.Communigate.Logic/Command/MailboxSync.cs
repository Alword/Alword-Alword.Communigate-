using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	[XmlRoot("mailboxSync")]
	public class MailboxSync : BaseCommand
	{
		/// <summary>имя Представления папки</summary>
		[XmlAttribute("folder")]
		public string Folder { get; set; } = string.Empty;

		/// <summary>
		/// строка, идентифицирующая клиентское приложение; для каждого такого приложения 
		/// сервер поддерживает отдельную историю изменений.
		/// </summary>
		[XmlAttribute("clientID")]
		public string ClientId { get; set; } = "LocalClient";

		/// <summary>строка, являющаяся ключом синхронизации; при первом обращении надо использовать значение "0".</summary>
		[XmlAttribute("syncID")]
		public int SyncID { get; set; }

		///// <summary>необязательный параметр, указывающий максимальное количество записей в ответе.</summary>
		//[XmlAttribute("limit")]
		//public int? Limit { get; set; }

		///// <summary>необязательный параметр - отметка времени для самого старого сообщения в ответе.</summary>
		//[XmlAttribute("timeFrom")]
		//public DateTime? TimeFrom { get; set; }

		///// <summary>необязательный параметр для ограничения размера записи в ответе для каждого сообщения.</summary>
		//[XmlAttribute("timeFrom")]
		//public int? TotalSizeLimit { get; set; }
	}
}
