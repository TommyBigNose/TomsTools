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

namespace TomsTools.Tests.Commands
{
	public class HtmlStringCleanserCommandTests
	{
		private IStringCleanser _stringCleanser;
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_stringCleanser = new HtmlStringCleanser();
			_clipboardTool = new WindowsClipboardTool();
			_sut = new HtmlStringCleanserCommand(_stringCleanser, _clipboardTool);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_Pass_When_Valid()
		{
			// Arrange
			_clipboardTool.SetText(TestConstants.SAMPLE_HTML);

			// Act
			_sut.Execute();
			var result = _clipboardTool.GetText();

			// Assert
			// Assert
			Assert.Multiple(() => {
				Assert.That(result, Does.Not.Contain(@"<div"), "HtmlStringCleanserCommand did not clean out divs");
				Assert.That(result, Does.Not.Contain(@"<body"), "HtmlStringCleanserCommand did not clean out bodys");
			});
		}
	}
}
