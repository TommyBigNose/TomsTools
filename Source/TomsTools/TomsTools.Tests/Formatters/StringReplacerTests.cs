using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;
using NUnit.Framework.Constraints;

namespace TomsTools.Tests.Formatters
{
	public class StringReplacerTests
	{
		private IStringReplacer _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new StringReplacer();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[TestCase("Test", null, "")]
		[TestCase("Test", "", null)]
		[TestCase(null, "", "")]
		[TestCase("Test", "", "")]
		public void Should_NotBeAbleToReplace_When_InvalidInput(string text, string oldCharacter, string newCharacter)
		{
			// Arrange
			// Act
			var result = _sut.CanReplace(text, oldCharacter, newCharacter);

			// Assert
			Assert.That(result, Is.False, "StringReplacer failed to notice invalid arguments");
		}

		[TestCase("I need some, ya know, \"stuff\"", "\"", "", true)]
		[TestCase("I need some, ya know, \"stuff\"", "\"", "\"\"", false)]
		[TestCase(@"C:\\Fake\\Path", "\\\\", "\\", true)]
		public void Should_ReplaceText(string text, string oldCharacter, string newCharacter, bool isOldCompletelyGone)
		{
			// Arrange
			Constraint constraint = (isOldCompletelyGone)? Does.Not.Contain(oldCharacter): Does.Contain(newCharacter);

			// Act
			var result = _sut.Replace(text, oldCharacter, newCharacter);

			// Assert
			Assert.That(result, constraint, @$"StringReplacer failed the following constraint: {constraint.Description}");
		}
		// I need some, ya know, "stuff"
	}
}