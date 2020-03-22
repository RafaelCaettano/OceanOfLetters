using Newtonsoft.Json;
using System.Collections.Generic;

namespace OceanOfLettersAPI.Models
{

    public class Country
    {

        public Country()
        {
            Books = new HashSet<Book>();
            Authors = new HashSet<Author>();
        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        #endregion

        #region Navigation Properties

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("authors")]
        public ICollection<Author> Authors { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeLanguage() { return Language != null; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }

        #endregion

    }

}
