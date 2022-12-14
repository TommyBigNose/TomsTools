using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using TomsTools.Commands;
using TomsTools.Data;
using TomsTools.Formatters;
using TomsTools.General;
using TomsTools.Guids;
using TomsTools.Templates;

namespace TomsTools.App.Forms
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var host = CreateHostBuilder().Build();
			ServiceProvider = host.Services;

			Application.Run(ServiceProvider.GetRequiredService<Form1>());
		}

		public static IServiceProvider? ServiceProvider { get; private set; }
		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) => {
					services.AddSingleton<CommandManager>();
					services.AddSingleton<IDataSource, LocalDataSource>();
					services.AddScoped<IGuidGenerator, GuidGenerator>();
					services.AddScoped<IStringReplacer, StringReplacer>();
					services.AddScoped<IStringCleanser, HtmlStringCleanser>();
					services.AddScoped<ITemplateSelector, StringTemplateSelector>();
					services.TryAddEnumerable(new[]
					{
						ServiceDescriptor.Scoped<IStringFormatter, JsonStringFormatter>(),
					});
					services.AddScoped<IClipboardTool, WindowsClipboardTool>();
					services.AddTransient<Form1>();
				});
		}
	}
}