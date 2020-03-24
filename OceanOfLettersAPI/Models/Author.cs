using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    [JsonObject(IsReference = true)]
    public class Author
    {

        public Author()
        {

            AuthorsBooks = new HashSet<AuthorsBook>();
            AuthorsSeries = new HashSet<AuthorsSeries>();
            GenresAuthors = new HashSet<GenresAuthor>();
            PublishingCompaniesAuthors = new HashSet<PublishingCompaniesAuthor>();
            BrandsAuthors = new HashSet<BrandsAuthor>();
            PublishingCompanies = new List<PublishingCompany>();
            Books = new List<Book>();
            Series = new List<Series>();
            Genres = new List<Genre>();
            Brands = new List<Brand>();

        }

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

        #region Navigation Properties

        [JsonProperty("country")]
        public Country Country { get; set; }

        [NotMapped]
        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [NotMapped]
        [JsonProperty("publishing_companies")]
        public ICollection<PublishingCompany> PublishingCompanies { get; set; }

        [NotMapped]
        [JsonProperty("series")]
        public ICollection<Series> Series { get; set; }

        [NotMapped]
        [JsonProperty("genres")]
        public ICollection<Genre> Genres { get; set; }

        [NotMapped]
        [JsonProperty("brands")]
        public ICollection<Brand> Brands { get; set; }

        [JsonProperty("brands_authors")]
        public ICollection<BrandsAuthor> BrandsAuthors { get; set; }

        [JsonProperty("authors_books")]
        public ICollection<AuthorsBook> AuthorsBooks { get; set; }

        [JsonProperty("authors_series")]
        public ICollection<AuthorsSeries> AuthorsSeries { get; set; }

        [JsonProperty("genres_authors")]
        public ICollection<GenresAuthor> GenresAuthors { get; set; }

        [JsonProperty("publishing_companies_author")]
        public ICollection<PublishingCompaniesAuthor> PublishingCompaniesAuthors { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeSeries() { return Series.Count > 0; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeCountry() { return Country != null; }
        public bool ShouldSerializeBrands() { return Brands.Count > 0; }
        public bool ShouldSerializePublishingCompanies() { return PublishingCompanies.Count > 0; }
        public bool ShouldSerializeAuthorsBooks() { return false; }
        public bool ShouldSerializeAuthorsSeries() { return false; }
        public bool ShouldSerializeGenresAuthors() { return false; }
        public bool ShouldSerializeBrandsAuthors() { return false; }
        public bool ShouldSerializePublishingCompaniesAuthors() { return false; } 

        #endregion

    }

}
