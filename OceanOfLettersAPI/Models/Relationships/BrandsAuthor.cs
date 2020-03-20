using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models.Relationships
{

    [JsonObject(IsReference = true)]
    public partial class BrandsAuthor
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

    }

}
