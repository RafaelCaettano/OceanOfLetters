using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models.Relationships
{
    [JsonObject(IsReference = true)]
    public partial class AuthorsBook
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty("book_id")]
        public int? BookId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("book")]
        public Book Book { get; set; }

    }
}
