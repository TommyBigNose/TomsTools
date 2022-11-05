using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace TomsTools.Formatters
{
	public class HtmlStringCleanser : IStringCleanser
	{
		public string Cleanse(string text)
		{
			try
			{
				HtmlDocument doc = new HtmlDocument();
				text = $"<body>{text}</body>";
				doc.LoadHtml(text);
				string cleansedHtml = doc.DocumentNode.SelectSingleNode("//body").InnerText;
				return cleansedHtml;
			}
			catch
			{
				string message = "Current text in clipboard is valid HTML";
				throw new ArgumentException(message);
			}
		}
	}
}
