using Newtonsoft.Json;
using System.Collections.Generic;

namespace OceanOfLettersAPI.Models
{

    public class Language
    {

        public Language()
        {

            Books = new HashSet<Book>();
            Countries = new HashSet<Country>();

        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("countries")]
        public ICollection<Country> Countries { get; set; }

        #endregion

    }

}
