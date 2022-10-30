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
	public class StringReplacerCommand : ICommand
	{
		private readonly IStringReplacer _stringReplacer;
		private readonly IClipboardTool _clipboardTool;
		private string _text;
		private string _oldCharacter;
		private string _newCharacter;

		public StringReplacerCommand(IStringReplacer stringReplacer, IClipboardTool clipboardTool)
		{
			_stringReplacer = stringReplacer;
			_clipboardTool = clipboardTool;
			_text = string.Empty;
			_oldCharacter = string.Empty;
			_newCharacter = string.Empty;
		}


		public bool CanExecute()
		{
			return true;
		}

		public void Execute(string[]? args = null)
		{
			if (args != null)
			{
				_oldCharacter = args[0];
				_newCharacter = args[1];
				_text = _stringReplacer.Replace(_clipboardTool.GetText(), _oldCharacter, _newCharacter);
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
