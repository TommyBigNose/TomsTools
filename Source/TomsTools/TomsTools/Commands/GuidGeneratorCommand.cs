using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Guids;
using System.Windows;
using System.Windows.Forms;
using TomsTools.General;

namespace TomsTools.Commands
{
	public class GuidGeneratorCommand : ICommand
	{
		private readonly IGuidGenerator _guidGenerator;
		private readonly IClipboardTool _clipboardTool;
		private Guid _guid;

		public string Name { get; }

		public GuidGeneratorCommand(IGuidGenerator generator, IClipboardTool clipboardTool)
		{
			Name = "Generate Guid";
			_guidGenerator = generator;
			_clipboardTool = clipboardTool;
		}

		public bool CanExecute(string[]? args = null)
		{
			return true;
		}

		public void Execute(string[]? args = null)
		{
			_guid = _guidGenerator.GenerateGuid();
			_clipboardTool.SetText(_guid.ToString());
		}

		public void Undo()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"{_guid}";
		}
	}
}
