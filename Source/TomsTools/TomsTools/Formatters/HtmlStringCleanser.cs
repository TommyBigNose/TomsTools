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
			HtmlDocument doc = new HtmlDocument();
			text = $"<body>{text}</body>";
			doc.LoadHtml(text);
			string cleansedHtml = doc.DocumentNode.SelectSingleNode("//body").InnerText;
			return cleansedHtml;
		}
	}
}
