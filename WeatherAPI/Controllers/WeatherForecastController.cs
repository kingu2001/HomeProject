using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=fc4747c60f1299d385354a09ad74e412");
                response.EnsureSuccessStatusCode(); 
                var data = await response.Content.ReadAsStringAsync();
                return Content(data,"Application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"API Request failed: {ex.Message}");
            }
        }
    }
}