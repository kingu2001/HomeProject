using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7082/api/WeatherForecast/");
            using HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            Root forecast = JsonSerializer.Deserialize<Root>(responseBody);
            //Console.WriteLine(forecast.name);
            //Console.WriteLine(forecast.main.temp);
            //Console.WriteLine(forecast.main.feels_like);
            ViewData["Weather"] = forecast.weather;
            ViewData["IconUrl"] = $"https://openweathermap.org/img/wn/{forecast.weather.First().icon}.png";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}