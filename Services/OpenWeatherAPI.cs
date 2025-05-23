using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http;
using WeatherDataAPI.Models;

namespace WeatherDataAPI.Services
{
    public class OpenWeatherApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "8a8c857ceacd127131b111ebe25d420d";

        public OpenWeatherApi(HttpClient httpClient)
        {
            this._httpClient = httpClient;

        }
        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var weatherData = await response.Content.ReadAsStringAsync();
                return weatherData;
            }
            else
            {
                return ("Failed to get the weather data for the city: " + city);
            }
            
        }
    }
}
