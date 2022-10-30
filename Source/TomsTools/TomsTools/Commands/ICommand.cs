namespace TomsTools.Commands
{
	public interface ICommand
	{
		void Execute(string[]? args = null);
		bool CanExecute();
		void Undo();
		string ToString();
	}
}
