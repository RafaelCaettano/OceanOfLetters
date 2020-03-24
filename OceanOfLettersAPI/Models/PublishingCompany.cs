using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    [JsonObject(IsReference = true)]
    public class PublishingCompany
    {

        public PublishingCompany()
        {

            Books = new HashSet<Book>();
            Brands = new HashSet<Brand>();
            PublishingCompaniesAuthors = new HashSet<PublishingCompaniesAuthor>();
            Authors = new List<Author>();
            GenresPublishingCompanies = new HashSet<GenresPublishingCompany>();
            PublishingCompaniesSeries = new HashSet<PublishingCompaniesSeries>();
            Genres = new List<Genre>();
            Series = new List<Series>();

        }

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

        #region Navigation Properties

        [NotMapped]
        [JsonProperty("authors")]
        public ICollection<Author> Authors { get; set; }

        [NotMapped]
        [JsonProperty("genres")]
        public ICollection<Genre> Genres { get; set; }

        [NotMapped]
        [JsonProperty("series")]
        public ICollection<Series> Series { get; set; }

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("publishing_companies_authors")]
        public ICollection<PublishingCompaniesAuthor> PublishingCompaniesAuthors { get; set; }

        [JsonProperty("genres_publishing_companies")]
        public ICollection<GenresPublishingCompany> GenresPublishingCompanies { get; set; }

        [JsonProperty("publishing_companies_series")]
        public ICollection<PublishingCompaniesSeries> PublishingCompaniesSeries { get; set; }

        [JsonProperty("brands")]
        public ICollection<Brand> Brands { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeSeries() { return Series.Count > 0; }
        public bool ShouldSerializeBrands() { return Brands.Count > 0; }
        public bool ShouldSerializePublishingCompaniesAuthors() { return false; }
        public bool ShouldSerializeGenresPublishingCompanies() { return false; }
        public bool ShouldSerializePublishingCompaniesSeries() { return false; }

        #endregion

    }

}
