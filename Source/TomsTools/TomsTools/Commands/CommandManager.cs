﻿using System.Text;

namespace TomsTools.Commands
{
	public class CommandManager
	{
		private Stack<ICommand> commands = new Stack<ICommand>();

		public void Invoke(ICommand command)
		{
			if (command.CanExecute())
			{
				commands.Push(command);
				command.Execute();
			}
		}

		public void Undo()
		{
			if (commands.Count > 0)
			{
				ICommand command = commands.Pop();
				command.Undo();
			}
		}

		public string GetCommandHistory()
		{
			StringBuilder stringBuilder = new();
			foreach(var command in commands)
			{
				stringBuilder.AppendLine(command.ToString());
			}

			return stringBuilder.ToString();
		}
	}
}