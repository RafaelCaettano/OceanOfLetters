using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models
{

    public class Author
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birth")]
        public DateTime Birth { get; set; }

        [JsonProperty("death")]
        public DateTime? Death { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("activity_period")]
        public string ActivityPeriod { get; set; }

        [JsonProperty("country_id")]
        public int? CountryId { get; set; }

        #endregion

    }

}
