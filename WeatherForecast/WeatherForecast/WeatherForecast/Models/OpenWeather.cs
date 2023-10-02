// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models;
public class OpenWeather
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Root
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

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

    public class RootSG
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

