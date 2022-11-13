using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomsTools.Data;

namespace TomsTools.Templates
{
	public class StringTemplateSelector : ITemplateSelector
	{
		private readonly IDataSource _dataSource;

		public StringTemplateSelector(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public string GetTemplate(int templateId)
		{
			string? template = "";

			var templates = _dataSource.GetStringTemplates().ToList();
			if (templates.Select(_=>_.Id).Contains(templateId))
			{
				template = templates.First(_ => _.Id == templateId).Value;
			}

			return (string.IsNullOrEmpty(template)?string.Empty:template);
		}
	}
}
