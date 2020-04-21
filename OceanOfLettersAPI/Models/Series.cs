using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    [JsonObject(IsReference = true)]
    public class Series
    {

        public Series()
        {

            Books = new HashSet<Book>();
            AuthorsSeries = new HashSet<AuthorsSeries>();
            Authors = new List<Author>();
            PublishingCompaniesSeries = new HashSet<PublishingCompaniesSeries>();
            BrandsSeries = new HashSet<BrandsSeries>();
            PublishingCompanies = new List<PublishingCompany>();
            Brands = new List<Brand>();
            GenresSeries = new HashSet<GenresSeries>();
            Genres = new List<Genre>();

        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("cover_id")]
        public int CoverId { get; set; }

        #endregion

        #region Navigation Properties

        [JsonProperty("books")]
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

        [JsonProperty("genres")]
        [NotMapped]
        public ICollection<Genre> Genres { get; set; }

        [JsonProperty("genres_series")]
        public ICollection<GenresSeries> GenresSeries { get; set; }

        [JsonProperty("authors_series")]
        public ICollection<AuthorsSeries> AuthorsSeries { get; set; }

        [JsonProperty("brands_series")]
        public ICollection<BrandsSeries> BrandsSeries { get; set; }

        [JsonProperty("publishing_companies_series")]
        public ICollection<PublishingCompaniesSeries> PublishingCompaniesSeries { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }
        public bool ShouldSerializeBrands() { return Brands.Count > 0; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeCover() { return Cover != null; }
        public bool ShouldSerializePublishingCompanies() { return PublishingCompanies.Count > 0; }
        public bool ShouldSerializeAuthorsSeries() { return false; }
        public bool ShouldSerializeBrandsSeries() { return false; }
        public bool ShouldSerializeGenresSeries() { return false; }
        public bool ShouldSerializePublishingCompaniesSeries() { return false; }

        #endregion

    }

}
