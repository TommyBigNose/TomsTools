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

namespace TomsTools.Tests.Commands
{
	public class StringReplacerCommandTests
	{
		private IStringReplacer _stringReplacer;
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_stringReplacer = new StringReplacer();
			_clipboardTool = new WindowsClipboardTool();
			_sut = new StringReplacerCommand(_stringReplacer, _clipboardTool);
		}

		[TearDown]
		public void TearDown()
		{
		}

		[TestCase("I need some, ya know, \"stuff\"", "\"", "", true)]
		[TestCase("I need some, ya know, \"stuff\"", "\"", "\"\"", false)]
		[TestCase(@"C:\\Fake\\Path", "\\\\", "\\", true)]
		public void Should_ReplaceText(string text, string oldCharacter, string newCharacter, bool isOldCompletelyGone)
		{
			// Arrange
			string[] args = new string[] { oldCharacter, newCharacter };
			Constraint constraint = (isOldCompletelyGone) ? Does.Not.Contain(oldCharacter) : Does.Contain(newCharacter);
			_clipboardTool.SetText(text);

			// Act
			_sut.Execute(args);
			var result = _clipboardTool.GetText();

			// Assert
			Assert.That(result, constraint, @$"StringReplacerCommand failed the following constraint: {constraint.Description}");
		}

		[TestCase("Test", null, "")]
		[TestCase("Test", "", null)]
		[TestCase("Test", "", "")]
		public void Should_NotBeAbleToExecute_When_CommandHasInvalidArgs(string text, string oldCharacter, string newCharacter)
		{
			// Arrange
			string[] args = new string[] { oldCharacter, newCharacter };
			_clipboardTool.SetText(text);

			// Act
			var result = _sut.CanExecute(args);

			// Assert
			Assert.That(result, Is.False, "StringReplacerCommand failed to notice invalid arguments");
		}
	}
}
