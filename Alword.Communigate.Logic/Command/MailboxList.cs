using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Command
{
	/// <summary>
	/// Эта операция заставляет Сервер отправить сообщение с данными mailbox (смотрите ниже) для каждой видимой Папки (Папки, к 
	/// аутентифицированный Пользователь имеет Права Доступа Видеть).
	/// </summary>
	[XmlRoot("mailboxList")]
	public class MailboxList : BaseCommand { }
}
