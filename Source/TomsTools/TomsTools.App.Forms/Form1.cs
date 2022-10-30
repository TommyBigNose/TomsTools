using TomsTools.Commands;

namespace TomsTools.App.Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnGenerateGuid_Click(object sender, EventArgs e)
		{
			ICommand command = new GuidGeneratorCommand(GuidGenerator, ClipboardTool);
			CommandManager.Invoke(command);
			txtCommandHistory.Text = CommandManager.GetCommandHistory();
		}
	}
}