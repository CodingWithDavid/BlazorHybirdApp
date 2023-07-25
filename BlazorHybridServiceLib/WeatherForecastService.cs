using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorHybridServiceLib
{
    public class WeatherForecastService
    {

        private bool hosted = false;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(bool isHosted)
        {

            hosted = isHosted;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            //from local
            if (hosted)
            {
                HttpClient httpClient = new HttpClient();
                var result =  await httpClient.GetFromJsonAsync<WeatherForecast[]>("https://localhost:7198/WeatherForecast");
                if (result == null)
                {
                    result = new WeatherForecast[0];
                }
                return result;
            }
            else
            { 
                return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(startDate.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray());
            }
        }
    }
}