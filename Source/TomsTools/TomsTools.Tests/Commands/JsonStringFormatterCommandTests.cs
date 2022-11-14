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
	public class JsonStringFormatterCommandTests
	{
		private IStringFormatter _stringFormatter;
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_stringFormatter = new JsonStringFormatter();
			_clipboardTool = new WindowsClipboardTool();
			_sut = new JsonStringFormatterCommand(_stringFormatter, _clipboardTool);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_Pass_When_Valid()
		{
			// Arrange
			// Arrange
			TestModel testModel = new TestModel()
			{
				Id = "FAKE-123",
				Name = "Test Guy"
			};
			string jsonText = JsonSerializer.Serialize(testModel);
			_clipboardTool.SetText(jsonText);

			// Act
			_sut.Execute();
			var result = _clipboardTool.GetText();

			// Assert
			// Assert
			Assert.That(result, Does.Contain("\r\n"), "JsonStringFormatterCommand did not format with indentation");
		}
	}
}
