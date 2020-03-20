using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class GenresBrand
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("genre_id")]
        public int? GenreId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("brands")]
        public Brand Brand { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

    }
}
