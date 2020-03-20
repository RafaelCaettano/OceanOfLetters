using Newtonsoft.Json;

namespace OceanOfLettersAPI.Models.Relationships
{
    public partial class GenresBook
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("genre_id")]
        public int? GenreId { get; set; }

        [JsonProperty("book_id")]
        public int? BookId { get; set; }

        [JsonProperty("book")]
        public Book Book { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

    }
}
