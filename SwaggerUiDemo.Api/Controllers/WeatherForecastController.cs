using Microsoft.AspNetCore.Mvc;

namespace SwaggerUiDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Returns weather forecasts. Completely random.
    /// </summary>
    /// <param name="amount">Number of weather forecasts.</param>
    /// <returns>List of weather forecasts</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public WeatherForecastResponse Get(int amount)
    {
        return new WeatherForecastResponse(
            amount, 
            Enumerable.Range(1, amount).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
    }
}

public record WeatherForecastResponse(int Amount, WeatherForecast[] Forecasts);