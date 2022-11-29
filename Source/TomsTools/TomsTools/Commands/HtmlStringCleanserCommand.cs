using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Guids;
using System.Windows;
using System.Windows.Forms;
using TomsTools.General;
using TomsTools.Formatters;

namespace TomsTools.Commands
{
	public class HtmlStringCleanserCommand : ICommand
	{
		private readonly IStringCleanser _stringCleanser;
		private readonly IClipboardTool _clipboardTool;
		private string _html;

		public string Name { get; }

		public HtmlStringCleanserCommand(IStringCleanser stringCleanser, IClipboardTool clipboardTool)
		{
			Name = "HTML Cleanser";
			_stringCleanser = stringCleanser;
			_clipboardTool = clipboardTool;
			_html = string.Empty;
		}

		public bool CanExecute(string[]? args = null)
		{
			return true;
		}

		public void Execute(string[]? args = null)
		{
			try
			{
				_html = _stringCleanser.Cleanse(_clipboardTool.GetText());
				_clipboardTool.SetText(_html);
			}
			catch
			{
				_clipboardTool.SetText(_clipboardTool.GetText());
			}
		}

		public void Undo()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"{_html}";
		}
	}
}
