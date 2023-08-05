using Microsoft.Extensions.Logging;

using BlazorHybridServiceLib;

namespace BlazorHtbridApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		bool hosted = false;

        builder.Services.AddSingleton<WeatherForecastService>(sp => new WeatherForecastService(hosted));

		return builder.Build();
	}
}
