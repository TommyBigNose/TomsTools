namespace TomsTools.Commands
{
	public interface ICommand
	{
		void Execute();
		bool CanExecute();
		void Undo();
		string ToString();
	}
}
