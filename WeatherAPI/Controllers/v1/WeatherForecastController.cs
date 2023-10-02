using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get(int daysChosen)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?lat=51.5156177&lon=-0.0919983&units&appid=7bf36c7d7f2a40883ce3a0a41b19bd5a";
            if (daysChosen == 1)
            {
                url = $"http://api.openweathermap.org/data/2.5/forecast?lat=51.5156177&lon=-0.0919983&units&cnt={daysChosen + 7}appid=7bf36c7d7f2a40883ce3a0a41b19bd5a";
            }
            else if (daysChosen == 2)
            {
                url = $"http://api.openweathermap.org/data/2.5/forecast?lat=51.5156177&lon=-0.0919983&units&cnt={daysChosen + 14}appid=7bf36c7d7f2a40883ce3a0a41b19bd5a";
            }
            else if (daysChosen == 3)
            {
                url = $"http://api.openweathermap.org/data/2.5/forecast?lat=51.5156177&lon=-0.0919983&units&cnt={daysChosen + 21}appid=7bf36c7d7f2a40883ce3a0a41b19bd5a";
            }
            else if (daysChosen == 4)
            {
                url = $"http://api.openweathermap.org/data/2.5/forecast?lat=51.5156177&lon=-0.0919983&units&cnt={daysChosen + 28}appid=7bf36c7d7f2a40883ce3a0a41b19bd5a";
            }
            if (daysChosen == 5)
            {

            }
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return Content(data, "Application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"API Request failed: {ex.Message}");
            }
        }
    }
}