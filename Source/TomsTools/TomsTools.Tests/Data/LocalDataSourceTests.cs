using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using System.Text.Json;
using NUnit.Framework.Constraints;
using TomsTools.Templates;
using TomsTools.Data;

namespace TomsTools.Tests.Data
{
	public class LocalDataSourceTests
	{
		private IDataSource _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new LocalDataSource();
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void Should_GetStringTemplates()
		{
			// Arrange
			// Act
			var result = _sut.GetStringTemplates();

			// Assert
			Assert.That(result.Any(), Is.True, @$"LocalDataSource failed to get templates");
		}
	}
}