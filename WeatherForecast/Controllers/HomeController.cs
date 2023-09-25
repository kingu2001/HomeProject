using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net.Http;
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

        public async Task<IActionResult> Index(int daysChosen)
        {
            string url = "https://localhost:7082/api/WeatherForecast";
            if (daysChosen != 0) 
            {
                url = $"https://localhost:7082/api/WeatherForecast?daysChosen={daysChosen}";
            }
            using HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            Root forecast = JsonSerializer.Deserialize<Root>(responseBody);
            foreach (var item in forecast.list)
            {
                item.main.temp = item.main.temp - 273.15;
            }
            //Console.WriteLine(forecast.name);
            //Console.WriteLine(forecast.main.temp);
            //Console.WriteLine(forecast.main.feels_like);
            ViewData["Weather"] = forecast.list;
            //ViewData["IconUrl"] = $"https://openweathermap.org/img/wn/{weather.weather.First().icon}.png";
            return View(forecast);
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