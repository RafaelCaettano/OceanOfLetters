using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models
{

    public class Book
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("launch")]
        public DateTime Launch { get; set; }

        [JsonProperty("pages")]
        public string Pages { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        [JsonProperty("country_id")]
        public int? CountryId { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        #endregion

    }

}
