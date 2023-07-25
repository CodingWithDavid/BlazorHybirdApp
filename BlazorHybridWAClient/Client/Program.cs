using BlazorHybridServiceLib;
using BlazorHybridWAClient.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
bool hosted = true;
builder.Services.AddSingleton<WeatherForecastService>(sp => new WeatherForecastService(hosted));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
