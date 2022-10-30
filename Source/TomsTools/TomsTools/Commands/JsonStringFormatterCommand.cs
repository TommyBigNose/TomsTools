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
	public class JsonStringFormatterCommand : ICommand
	{
		private readonly IStringFormatter _stringFormatter;
		private readonly IClipboardTool _clipboardTool;
		private string _json;

		public JsonStringFormatterCommand(IStringFormatter stringFormatter, IClipboardTool clipboardTool)
		{
			_stringFormatter = stringFormatter;
			_clipboardTool = clipboardTool;
		}


		public bool CanExecute()
		{
			return true;
		}

		public void Execute()
		{
			try
			{
				_json = _stringFormatter.Format(_clipboardTool.GetText());
				_clipboardTool.SetText(_json);
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
			return $"{_json}";
		}
	}
}
