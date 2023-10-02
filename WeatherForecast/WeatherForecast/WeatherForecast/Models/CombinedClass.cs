using WeatherForecast.Models;
namespace WeatherForecast.Models
{
	public class CombinedClass
	{
        public OpenWeather.Root ow { get; set; }
        public StormGlass.Root gs { get; set; }
        public CombinedClass(OpenWeather.Root ow, StormGlass.Root gs)
		{
			this.ow = ow;
			this.gs = gs;
		}
	}
}
