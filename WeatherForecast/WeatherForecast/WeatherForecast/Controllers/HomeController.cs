using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient _client;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_client = new HttpClient();
		}

		public async Task<IActionResult> Index()
		{
			//List<Root> forecasts = new List<Root>();
			//using HttpResponseMessage response = await _client.GetAsync("https://localhost:7207/GetWeather");
			//response.EnsureSuccessStatusCode();
			//string responseBody = await response.Content.ReadAsStringAsync();

			//Root forecast = JsonSerializer.Deserialize<Root>(responseBody)!;

			return View();
		}

		public async Task<IActionResult> Forecasts(int numOfDays, string unit)
		{
			string baseURL = "https://localhost:7207/GetWeather";
			string urlWithNumOfDays = $"?numOfDays={numOfDays}";
			string urlWithUnit = $"&unit={unit}";
            OpenWeather.Root result = new OpenWeather.Root();
			
			if (unit == null)
			{
				string url = baseURL + urlWithNumOfDays;
				using HttpResponseMessage response = await _client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();

				OpenWeather.Root forecast = JsonSerializer.Deserialize<OpenWeather.Root>(responseBody)!;
				result = forecast;
			}
			else
			{
				string url = baseURL + urlWithNumOfDays + urlWithUnit;
				using HttpResponseMessage response = await _client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				OpenWeather.Root forecast = JsonSerializer.Deserialize<OpenWeather.Root>(responseBody)!;
				result = forecast;
			}
			
			
			return View(result);		
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