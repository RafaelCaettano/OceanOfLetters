using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    public class Genre
    {

        public Genre()
        {

            GenresBooks = new HashSet<GenresBook>();
            Books = new List<Book>();
            GenresAuthors = new HashSet<GenresAuthor>();
            Authors = new List<Author>();
            GenresPublishingCompanies = new HashSet<GenresPublishingCompany>();
            PublishingCompanies = new List<PublishingCompany>();
            Brands = new List<Brand>();
            GenresBrands = new HashSet<GenresBrand>();
            GenresSeries = new HashSet<GenresSeries>();
            Series = new List<Series>();

        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        [JsonProperty("books")]
        [NotMapped]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("authors")]
        [NotMapped]
        public ICollection<Author> Authors { get; set; }

        [JsonProperty("brands")]
        [NotMapped]
        public ICollection<Brand> Brands { get; set; }

        [JsonProperty("publishing_companies")]
        [NotMapped]
        public ICollection<PublishingCompany> PublishingCompanies { get; set; }

        [JsonProperty("series")]
        [NotMapped]
        public ICollection<Series> Series { get; set; }

        [JsonProperty("genres_series")]
        public ICollection<GenresSeries> GenresSeries { get; set; }

        [JsonProperty("genres_books")]
        public ICollection<GenresBook> GenresBooks { get; set; }

        [JsonProperty("genres_brands")]
        public ICollection<GenresBrand> GenresBrands { get; set; }

        [JsonProperty("genres_publishing_companies")]
        public ICollection<GenresPublishingCompany> GenresPublishingCompanies { get; set; }

        [JsonProperty("genres_authors")]
        public ICollection<GenresAuthor> GenresAuthors { get; set; }

        #endregion

    }

}
