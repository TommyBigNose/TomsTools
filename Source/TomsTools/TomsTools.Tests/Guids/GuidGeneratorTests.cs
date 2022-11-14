using TomsTools.Guids;

namespace TomsTools.Tests.Guids
{
	public class GuidGeneratorTests
	{
		private IGuidGenerator _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new GuidGenerator();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_GenerateGuid()
		{
			// Arrange
			// Act
			// Assert
			Assert.DoesNotThrow(() => _sut.GenerateGuid(), "GuidGenerator failed to generate a new guid");
		}

		[Test]
		public void Should_UniqueGuids_When_RunMultipleTimes()
		{
			// Arrange
			// Act
			var result1 = _sut.GenerateGuid();
			var result2 = _sut.GenerateGuid();

			// Assert
			Assert.That(result1, Is.Not.EqualTo(result2), "GuidGenerator failed to generate a unique guid");
		}
	}
}