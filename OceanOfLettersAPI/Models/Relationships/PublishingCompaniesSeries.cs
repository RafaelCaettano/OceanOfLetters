using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class PublishingCompaniesSeries
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

    }
}
