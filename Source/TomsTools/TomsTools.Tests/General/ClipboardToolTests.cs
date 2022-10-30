using TomsTools.General;
using TomsTools.Guids;

namespace TomsTools.Tests.General
{
	public class ClipboardToolTests
	{
		private IClipboardTool _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new WindowsClipboardTool();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_SetText()
		{
			// Arrange
			// Act
			// Assert
			Assert.DoesNotThrow(() => _sut.SetText("test"), "WindowsClipboardTool failed to set clipboard");
		}
	}
}