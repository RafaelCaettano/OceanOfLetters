using Newtonsoft.Json;
using OceanOfLettersAPI.Collections;
using OceanOfLettersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Utilities
{

    public class Response
    {

        public Response()
        {

            SerializeMessage = true;
            Authors = new Authors<Author>();
            Brands = new Brands<Brand>();
            Books = new Books<Book>();
            Countries = new Countries<Country>();
            Genres = new Genres<Genre>();
            Languages = new Languages<Language>();
            PublishingCompanies = new PublishingCompanies<PublishingCompany>();
            Series = new Serie<Series>();

        }

        #region Properties

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public bool BadRequest { get; set; }

        [JsonIgnore]
        public bool SerializeMessage { get; set; } 

        #endregion

        #region Collections

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("authors")]
        public ICollection<Author> Authors { get; set; }

        [JsonProperty("brands")]
        public ICollection<Brand> Brands { get; set; }

        [JsonProperty("countries")]
        public ICollection<Country> Countries { get; set; }

        [JsonProperty("genres")]
        public ICollection<Genre> Genres { get; set; }

        [JsonProperty("languages")]
        public ICollection<Language> Languages { get; set; }

        [JsonProperty("publishing_companies")]
        public ICollection<PublishingCompany> PublishingCompanies { get; set; }

        [JsonProperty("series")]
        public ICollection<Series> Series { get; set; }

        #endregion

        #region Objects

        [JsonProperty("book")]
        public Book Book { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

        [JsonProperty("serie")]
        public Series Serie { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeMessage() { return SerializeMessage; }

        #region Serialize Collections

        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }
        public bool ShouldSerializeBrands() { return Brands.Count > 0; }
        public bool ShouldSerializeCountries() { return Countries.Count > 0; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeLanguages() { return Languages.Count > 0; }
        public bool ShouldSerializePublishingCompanies() { return PublishingCompanies.Count > 0; }
        public bool ShouldSerializeSeries() { return Series.Count > 0; }

        #endregion

        #region Serialize Objects

        public bool ShouldSerializeBook() { return Book != null; }
        public bool ShouldSerializeCover() { return Cover != null; }
        public bool ShouldSerializeAvatar() { return Avatar != null; }
        public bool ShouldSerializeAuthor() { return Author != null; }
        public bool ShouldSerializeBrand() { return Brand != null; }
        public bool ShouldSerializeCountry() { return Country != null; }
        public bool ShouldSerializeGenre() { return Genre != null; }
        public bool ShouldSerializeLanguage() { return Language != null; }
        public bool ShouldSerializePublishingCompany() { return PublishingCompany != null; }
        public bool ShouldSerializeSerie() { return Serie != null; }  

        #endregion

        #endregion

    }

}
