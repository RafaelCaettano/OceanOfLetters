using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class PublishingCompaniesAuthor
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

    }
}
