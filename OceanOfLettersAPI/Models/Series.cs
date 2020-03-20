using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Series
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        #endregion

    }

}
