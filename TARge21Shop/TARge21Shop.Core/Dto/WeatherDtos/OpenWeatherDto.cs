using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherDto
    {
        [JsonPropertyName("coord")]
        public Coords Coord { get; set; }
        [JsonPropertyName("weather")]
        public List<Weathers> Weather { get; set; }
        [JsonPropertyName("main")]
        public Mains Main { get; set; }
        [JsonPropertyName("wind")]
        public Winds Wind { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        public class Coords
        {
            [JsonPropertyName("lon")]
            public double Lon { get; set; }
            public double Lat { get; set; }
        }
        public class Mains
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }
            public int Humidity { get; set; }
            public int Pressure { get; set; }
            public double Feels_like { get; set; }
        }
        public class Weathers
        {
            [JsonPropertyName("main")]
            public string Main { get; set; }
            public string Description { get; set; }
        }

        public class Winds
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }
        }
    }
}
