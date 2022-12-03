using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TomsTools.Commands;
using TomsTools.Data;
using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using TomsTools.Tests.Formatters;
using System.Text.Json;

namespace TomsTools.Tests.Commands
{
	public class PlainTextFormatterCommandTests
	{
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_clipboardTool = new WindowsClipboardTool();
			_sut = new PlainTextFormatterCommand(_clipboardTool);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_GetPlainText()
		{
			// Arrange
			var test = _clipboardTool.GetText();
			string formattedText = "TEST";
			_clipboardTool.SetText(test);

			// Act
			_sut.Execute();
			var result = _clipboardTool.GetText();

			// Assert
			Assert.That(result, Is.Not.EqualTo(formattedText), "PlainTextFormatterCommand did not format as plain text");
		}
	}
}
