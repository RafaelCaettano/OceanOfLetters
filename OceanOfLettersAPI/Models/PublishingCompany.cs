using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models
{

    public class PublishingCompany
    {

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("foundation")]
        public DateTime Foundation { get; set; }

        [JsonProperty("founders")]
        public string Founders { get; set; }

        [JsonProperty("headquarters")]
        public string Headquarters { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        #endregion

    }

}
