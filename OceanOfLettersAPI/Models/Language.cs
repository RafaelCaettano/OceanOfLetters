using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Language
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion

    }

}
