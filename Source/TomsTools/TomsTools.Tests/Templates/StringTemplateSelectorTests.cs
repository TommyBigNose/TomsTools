using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;
using NUnit.Framework.Constraints;
using TomsTools.Templates;

namespace TomsTools.Tests.Templates
{
	public class LocalDataSourceTests
	{
		private ITemplateSelector _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new StringTemplateSelector();
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