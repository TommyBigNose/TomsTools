using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TomsTools.Commands;
using TomsTools.Data;
using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using TomsTools.Templates;

namespace TomsTools.Tests.Commands
{
	public class StringTemplateSelectorCommandTests
	{
		private IDataSource _dataSource;
		private ITemplateSelector _templateSelector;
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_dataSource = new LocalDataSource();
			_templateSelector = new StringTemplateSelector(_dataSource);
			_clipboardTool = new WindowsClipboardTool();
			_sut = new StringTemplateSelectorCommand(_templateSelector, _clipboardTool);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[TestCase(0)]
		public void Should_GetTemplate(int templateId)
		{
			// Arrange
			string[] args = new string[] { "0" };

			// Act
			_sut.Execute(args);
			var result = _clipboardTool.GetText();

			// Assert
			Assert.That(result, Does.Contain("[Test]"), @$"StringTemplateSelectorCommand failed to get template {templateId}");
		}
	}
}
