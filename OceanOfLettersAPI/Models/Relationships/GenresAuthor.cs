using Newtonsoft.Json;
using System;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class GenresAuthor
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty("genre_id")]
        public int? GenreId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

    }
}
