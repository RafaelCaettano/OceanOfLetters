using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    public class Book
    {

        public Book()
        {
            AuthorsBook = new HashSet<AuthorsBook>();
            GenresBooks = new HashSet<GenresBook>();
            Authors = new List<Author>();
            Genres = new List<Genre>();
        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("launch")]
        public DateTime Launch { get; set; }

        [JsonProperty("pages")]
        public string Pages { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        [JsonProperty("country_id")]
        public int? CountryId { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("series_id")]
        public int? SeriesId { get; set; }

        #endregion

        #region Navigation Properties

        [JsonProperty("authors_books")]
        public ICollection<AuthorsBook> AuthorsBook { get; set; }

        [JsonProperty("genres_books")]
        public ICollection<GenresBook> GenresBooks { get; set; }

        [JsonProperty("authors")]
        [NotMapped]
        public ICollection<Author> Authors { get; set; }

        [JsonProperty("genres")]
        [NotMapped]
        public ICollection<Genre> Genres { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeAuthorsBook() { return false; }
        public bool ShouldSerializeGenresBooks() { return false; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }
        public bool ShouldSerializeSeries() { return Series != null; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeLanguage() { return Language != null; }
        public bool ShouldSerializeCountry() { return Country != null; }
        public bool ShouldSerializePublishingCompany() { return PublishingCompany != null; }
        public bool ShouldSerializeBrand() { return Brand != null; }

        #endregion

    }

}
