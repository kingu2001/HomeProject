using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text.Json;
using WeatherForecast.Models;

namespace WeatherForecastAPI.Controller.v2
{
	[Route("api2/GetWeather")]
	[ApiVersion("2.0")]
	public class API2Controller : ControllerBase
	{
		public readonly HttpClient _httpClient;
		public API2Controller(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IActionResult> GetWeatherForecast(int numOfDays, string unit)
		{
			string responseBody = "";
			string responseBody2 = "";
			
				int totalTimeStamps = numOfDays * 8;
				using HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?lat=55.40367357865401&lon=10.379796176974024&units={unit}&cnt={totalTimeStamps}&appid=b2eb1817e794b2764020207d96717449");
				response.EnsureSuccessStatusCode();
				using HttpResponseMessage response2 = await _httpClient.GetAsync($"https://api.stormglass.io/v2/weather/point?lat=58.7984&lng=17.8081&params=swellHeight,swellPeriod&key=3d80123a-60ff-11ee-8b7f-0242ac130002-3d80129e-60ff-11ee-8b7f-0242ac130002");
				response2.EnsureSuccessStatusCode(); 
				responseBody = await response.Content.ReadAsStringAsync();
				responseBody2 = await response2.Content.ReadAsStringAsync();
				OpenWeather.Root forecast = JsonSerializer.Deserialize<OpenWeather.Root>(responseBody)!;
				StormGlass.Root storm = JsonSerializer.Deserialize<StormGlass.Root>(responseBody2)!;
				CombinedClass cc = new CombinedClass(forecast, storm);
				responseBody = JsonSerializer.Serialize<CombinedClass>(cc);
			
			return Content(responseBody, "Application/json");
		}
	}
}
