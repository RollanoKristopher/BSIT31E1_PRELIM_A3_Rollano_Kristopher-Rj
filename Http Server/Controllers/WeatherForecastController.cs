using Microsoft.AspNetCore.Mvc;
using Http_Server;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

    // GET
    [HttpGet]
    public IActionResult GetonSomething()
    {
        return Ok(_forecasts);
    }

    // POST
    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast forecast)
    {
        _forecasts.Add(forecast);

        return Ok("Forecast added successfully.");
    }

    // PUT
    [HttpPut("{date}")]
    public IActionResult Put(DateOnly date, [FromBody] WeatherForecast updatedForecast)
    {
        var forecast = _forecasts.FirstOrDefault(f => f.Date == date);

        if (forecast == null)
        {
            return NotFound("Forecast not found.");
        }

        forecast.Date = updatedForecast.Date;
        forecast.TemperatureC = updatedForecast.TemperatureC;
        forecast.Summary = updatedForecast.Summary;

        return Ok("Forecast updated successfully.");
    }

    // DELETE
    [HttpDelete("{date}")]
    public IActionResult Delete(DateOnly date)
    {
        var forecast = _forecasts.FirstOrDefault(f => f.Date == date);

        if (forecast == null)
        {
            return NotFound("Forecast not found.");
        }

        _forecasts.Remove(forecast);

        return Ok("Forecast deleted successfully.");
    }
}