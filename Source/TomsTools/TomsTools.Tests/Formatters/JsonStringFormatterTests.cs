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
		public void Should_NotBeAbleToFormat_When_InvalidInput()
		{
			// Arrange
			string jsonText = "Not valid JSON {}";

			// Act
			var result = _sut.CanFormat(jsonText);

			// Assert
			Assert.That(result, Is.False, "JsonStringFormatter failed to notice invalid JSON");
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

	// {"Id":"FAKE-123","Name":"Test Guy"}
	internal class TestModel
	{
		public string? Id { get; set; }
		public string? Name { get; set; }
	}
}