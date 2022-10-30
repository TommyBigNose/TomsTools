using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TomsTools.Commands;
using TomsTools.General;
using TomsTools.Guids;

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
			//// To customize application configuration such as set high DPI settings or default font,
			//// see https://aka.ms/applicationconfiguration.
			//ApplicationConfiguration.Initialize();
			//Application.Run(new Form1());
		}

		public static IServiceProvider ServiceProvider { get; private set; }
		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) => {
					services.AddSingleton<CommandManager>();
					services.AddTransient<IGuidGenerator, GuidGenerator>();
					services.AddTransient<IClipboardTool, WindowsClipboardTool>();
					services.AddTransient<Form1>();
				});
		}
	}
}