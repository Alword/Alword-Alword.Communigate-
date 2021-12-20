using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Alword.Communigate.Logic.Utils
{
	public static class Xmls
	{
		public static string From<T>(T model) where T : class, new()
		{
			XmlSerializer xsSubmit = new(typeof(T));
			using StringWriter? sww = new();
			using XmlWriter writer = XmlWriter.Create(sww);
			xsSubmit.Serialize(writer, model);
			XDocument xdoc = XDocument.Parse(sww.ToString());
			xdoc.Declaration = null;

			xdoc.Descendants()
			   .Attributes()
			   .Where(x => x.IsNamespaceDeclaration)
			   .Remove();
			foreach (var elem in xdoc.Descendants())
				elem.Name = elem.Name.LocalName;
			var message = xdoc.ToString();
			return message;
		}
		public static T As<T>(XDocument xd)
		{
			XmlSerializer s = new(typeof(T));
			return (T)s.Deserialize(xd.CreateReader())!;
		}
	}
}
