using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Country
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        #endregion

    }

}
