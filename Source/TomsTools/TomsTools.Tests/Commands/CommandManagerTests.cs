using System.Windows.Forms;
using TomsTools.Commands;
using TomsTools.General;
using TomsTools.Guids;

namespace TomsTools.Tests.Commands
{
	public class CommandManagerTests
	{
		private CommandManager _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new CommandManager();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_RunCommand()
		{
			// Arrange
			IGuidGenerator guidGenerator = new GuidGenerator();
			IClipboardTool clipboardTool = new WindowsClipboardTool();
			ICommand command = new GenerateGuidCommand(guidGenerator, clipboardTool);

			// Act
			// Assert
			Assert.DoesNotThrow(() => _sut.Invoke(command), "CommandManager failed invoke a single command");
		}

		[Test]
		public void Should_GetCommandHistory()
		{
			// Arrange
			IGuidGenerator guidGenerator = new GuidGenerator();
			IClipboardTool clipboardTool = new WindowsClipboardTool();
			ICommand command = new GenerateGuidCommand(guidGenerator, clipboardTool);

			// Act
			_sut.Invoke(command);
			var result = _sut.GetCommandHistory();

			// Assert
			Assert.That(result, Does.Contain("Guid"), "CommandManager failed to get history of commands");
		}
	}
}