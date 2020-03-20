using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class BrandsSeries
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

    }
}
