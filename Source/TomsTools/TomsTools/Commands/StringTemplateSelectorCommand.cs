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
using TomsTools.Templates;

namespace TomsTools.Commands
{
	public class StringTemplateSelectorCommand : ICommand
	{
		private readonly ITemplateSelector _templateSelector;
		private readonly IClipboardTool _clipboardTool;
		private string _text;
		private int _templateId;

		public string Name { get; }

		public StringTemplateSelectorCommand(ITemplateSelector templateSelector, IClipboardTool clipboardTool)
		{
			Name = "Copy Template";
			_templateSelector = templateSelector;
			_clipboardTool = clipboardTool;
			_text = string.Empty;
		}

		public bool CanExecute(string[]? args = null)
		{
			return true;
		}

		public void Execute(string[]? args = null)
		{
			if (args != null)
			{
				_templateId = int.Parse(args[0]);
				_text = _templateSelector.GetTemplate(_templateId);
				_clipboardTool.SetText(_text);
			}
		}

		public void Undo()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"{_text}";
		}
	}
}
