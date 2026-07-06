using System.Collections.Generic;
using System.Linq;

namespace Http_Server
{
    public class WeatherForecastService
    {
        private readonly List<WeatherForecast> forecasts = new();
        private int nextId = 1;

        public List<WeatherForecast> GetAll()
        {
            return forecasts;
        }

        public WeatherForecast? GetById(int id)
        {
            return forecasts.FirstOrDefault(x => x.Id == id);
        }

        public WeatherForecast Add(WeatherForecast forecast)
        {
            forecast.Id = nextId++;
            forecasts.Add(forecast);
            return forecast;
        }

        public bool Update(int id, WeatherForecast updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Date = updated.Date;
            existing.TemperatureC = updated.TemperatureC;
            existing.Summary = updated.Summary;

            return true;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;

            forecasts.Remove(item);
            return true;
        }
    }
}