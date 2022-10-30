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

		[TestCase("Test123")]
		public void Should_SetText(string text)
		{
			// Arrange
			// Act
			// Assert
			Assert.DoesNotThrow(() => _sut.SetText(text), "WindowsClipboardTool failed to set clipboard");
		}

		[Test]
		public void Should_Error_When_SettingTextWithNothing()
		{
			// Arrange
			// Act
			// Assert
			Assert.Throws<ArgumentNullException>(() => _sut.SetText(string.Empty), "WindowsClipboardTool allowed empty value clipboard");
		}

		[TestCase("Test123")]
		[TestCase("XXX")]
		public void Should_GetLastSetText_When_SetTextWasUsed(string text)
		{
			// Arrange
			// Act
			_sut.SetText(text);
			var result = _sut.GetText();

			// Assert
			Assert.That(result, Is.EqualTo(text), "WindowsClipboardTool did not set clipboard text as to specified value");
		}
	}
}