using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Cover
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("book")]
        public Book Book { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

    }

}
