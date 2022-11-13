using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Models;

namespace TomsTools.Data
{
	public class LocalDataSource : IDataSource
	{
		public IEnumerable<StringTemplate> GetStringTemplates()
		{
			IEnumerable<StringTemplate> templates = new List<StringTemplate>()
			{
				new StringTemplate()
				{
					Id = 0,
					Name = "Unit Test",
					Value = @"
		[Test]
		public void Should_Pass_When_Valid()
		{
			// Arrange
			// Act
			var result = _sut.Test();

			// Assert
			Assert.That(result, Is.Not.Null, ""Result was null"");
		}"
				},
				new StringTemplate()
				{
					Id = 1,
					Name = "Sample",
					Value = @"This is just a fun sample template!"
				}
			};

			return templates;
		}
	}
}
