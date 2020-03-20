using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class GenresSeries
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("genre_id")]
        public int? GenreId { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

    }
}
