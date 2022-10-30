using TomsTools.Commands;
using TomsTools.Formatters;

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
			UpdateCommandHistory();
		}

		private void btnFormatJson_Click(object sender, EventArgs e)
		{
			IStringFormatter formatter = StringFormatters.FirstOrDefault(_ => _.GetType() == typeof(JsonStringFormatter))!;
			ICommand command = new JsonStringFormatterCommand(formatter, ClipboardTool);
			CommandManager.Invoke(command);
			UpdateCommandHistory();
		}

		private void UpdateCommandHistory()
		{
			txtCommandHistory.Text = CommandManager.GetCommandHistory();
		}
	}
}