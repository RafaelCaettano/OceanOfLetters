using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models.Relationships
{
    [JsonObject(IsReference = true)]
    public partial class AuthorsSeries
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

    }
}
