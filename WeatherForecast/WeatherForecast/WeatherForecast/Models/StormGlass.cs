namespace WeatherForecast.Models
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class StormGlass
	{

		public class Hour
		{
			public SwellHeight swellHeight { get; set; }
			public SwellPeriod swellPeriod { get; set; }
			public DateTime time { get; set; }
		}

		public class Meta
		{
			public int cost { get; set; }
			public int dailyQuota { get; set; }
			public string end { get; set; }
			public double lat { get; set; }
			public double lng { get; set; }
			public List<string> @params { get; set; }
			public int requestCount { get; set; }
			public string start { get; set; }
		}

		public class Root
		{
			public List<Hour> hours { get; set; }
			public Meta meta { get; set; }
		}

		public class SwellHeight
		{
			public double dwd { get; set; }
			public double icon { get; set; }
			public double meteo { get; set; }
			public double noaa { get; set; }
			public double sg { get; set; }
		}

		public class SwellPeriod
		{
			public double dwd { get; set; }
			public double icon { get; set; }
			public double meteo { get; set; }
			public double noaa { get; set; }
			public double sg { get; set; }
		}


	}
}
