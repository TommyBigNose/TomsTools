using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;
using NUnit.Framework.Constraints;
using TomsTools.Templates;
using TomsTools.Data;

namespace TomsTools.Tests.Templates
{
	public class StringTemplateSelectorTests
	{
		private IDataSource _dataSource;
		private ITemplateSelector _sut;

		[SetUp]
		public void Setup()
		{
			_dataSource = new LocalDataSource();
			_sut = new StringTemplateSelector(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[TestCase(0)]
		public void Should_GetTemplate(int templateId)
		{
			// Arrange
			// Act
			var result = _sut.GetTemplate(templateId);

			// Assert
			Assert.That(result, Does.Contain("[Test]"), @$"StringTemplateSelector failed to get template {templateId}");
		}
	}
}