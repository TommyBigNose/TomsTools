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
	public class GenerateGuidCommand : ICommand
	{
		private readonly IGuidGenerator _guidGenerator;
		private readonly IClipboardTool _clipboardTool;
		private Guid _guid;

		public GenerateGuidCommand(IGuidGenerator generator, IClipboardTool clipboardTool)
		{
			_guidGenerator = generator;
			_clipboardTool = clipboardTool;
		}


		public bool CanExecute()
		{
			return true;
		}

		public void Execute()
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
			return $"{nameof(GenerateGuidCommand)} - Guid: {_guid}";
		}
	}
}
