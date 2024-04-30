using System.Text.Json.Serialization;

namespace Wheather.Proxy.Domain.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Localtime { get; set; }

        [JsonPropertyName("tz_id")]
        public string TzId { get; set; }

        [JsonPropertyName("Localtime_epoch")]
        public int LocaltimeEpoch { get; set; }
    }
}
