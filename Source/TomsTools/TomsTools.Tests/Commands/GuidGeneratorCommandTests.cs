using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TomsTools.Commands;
using TomsTools.Data;
using TomsTools.General;
using TomsTools.Guids;

namespace TomsTools.Tests.Commands
{
	public class GuidGeneratorCommandTests
	{
		private IGuidGenerator _guidGenerator;
		private IClipboardTool _clipboardTool;
		private ICommand _sut;

		[SetUp]
		public void Setup()
		{
			_guidGenerator= new GuidGenerator();
			_clipboardTool = new WindowsClipboardTool();
			_sut = new GuidGeneratorCommand(_guidGenerator, _clipboardTool);
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
			_sut.Execute();
			var result = Guid.TryParse(_clipboardTool.GetText(), out _);

			// Assert
			Assert.That(result, Is.True, "Guid Generator did not generate a guid");
		}
	}
}
