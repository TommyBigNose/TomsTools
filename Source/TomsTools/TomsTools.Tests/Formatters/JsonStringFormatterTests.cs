using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;

namespace TomsTools.Tests.Formatters
{
	public class JsonStringFormatterTests
	{
		private IStringFormatter _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new JsonStringFormatter();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_FormatJson()
		{
			// Arrange
			TestModel testModel = new TestModel()
			{
				Id = "FAKE-123",
				Name = "Test Guy"
			};
			string jsonText = JsonSerializer.Serialize(testModel);

			// Act
			var result = _sut.Format(jsonText);

			// Assert
			Assert.That(result, Does.Contain("\r\n"), "JsonStringFormatter did not format with indentation");
		}

		[Test]
		public void Should_Error_When_TextIsNotJson()
		{
			// Arrange
			// Act
			// Assert
			Assert.Throws<ArgumentException>(() => _sut.Format("Test"), "JsonStringFormatter did not fail with invalid json");
		}

	}

	internal class TestModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}
}