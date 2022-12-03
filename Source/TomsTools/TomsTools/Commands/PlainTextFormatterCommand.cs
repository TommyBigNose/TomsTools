using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Formatters;
using TomsTools.General;

namespace TomsTools.Commands
{
	public class PlainTextFormatterCommand : ICommand
	{
		private readonly IClipboardTool _clipboardTool;
		private string _text;

		public string Name { get; }

		public PlainTextFormatterCommand(IClipboardTool clipboardTool)
		{
			Name = "Plain Text";
			_clipboardTool = clipboardTool;
			_text = string.Empty;
		}


		public bool CanExecute(string[]? args = null)
		{
			return true;
		}

		public void Execute(string[]? args = null)
		{
			_text = _clipboardTool.GetText();
			_clipboardTool.SetText(_text);
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
