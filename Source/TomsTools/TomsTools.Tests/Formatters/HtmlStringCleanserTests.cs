using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;
using NUnit.Framework.Constraints;

namespace TomsTools.Tests.Formatters
{
	public class HtmlStringCleanserTests
	{
		private IStringCleanser _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new HtmlStringCleanser();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[TestCase(TestConstants.SAMPLE_HTML)]
		public void Should_ReplaceText(string text)
		{
			// Arrange
			// Act
			var result = _sut.Cleanse(text);

			// Assert
			Assert.Multiple(() => {
				Assert.That(result, Does.Not.Contain(@"<div"), "HtmlStringCleanser did not clean out divs");
				Assert.That(result, Does.Not.Contain(@"<body"), "HtmlStringCleanser did not clean out bodys");
			});
			
		}
	}
}