using System.Net.Http;
using System.Text;
using System.Text.Json;
using Http_Server;


public class WeatherForecastListResponse
{
    public List<WeatherForecast> Forecasts { get; set; } = new List<WeatherForecast>();
    public int Count => Forecasts?.Count ?? 0;
    public string? Message { get; set; }
}

