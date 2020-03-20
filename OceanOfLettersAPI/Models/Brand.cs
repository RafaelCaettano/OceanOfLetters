using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Brand
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        #endregion

    }

}
