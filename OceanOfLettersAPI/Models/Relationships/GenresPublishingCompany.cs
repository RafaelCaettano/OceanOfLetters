using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class GenresPublishingCompany
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("genre_id")]
        public int? GenreId { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

    }
}
