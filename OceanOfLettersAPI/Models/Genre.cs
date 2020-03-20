using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models
{

    public class Genre
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion

    }

}
