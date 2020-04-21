using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

    [JsonObject(IsReference = true)]
    public class Brand
    {

        public Brand()
        {
            Books = new HashSet<Book>();
            Authors = new List<Author>();
            BrandsAuthors = new HashSet<BrandsAuthor>();
            GenresBrands = new HashSet<GenresBrand>();
            BrandsSeries = new HashSet<BrandsSeries>();
            Genres = new List<Genre>();
            Series = new List<Series>();
        }

        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publishing_company_id")]
        public int? PublishingCompanyId { get; set; }

        [JsonProperty("avatar_id")]
        public int? AvatarId { get; set; }

        #endregion

        #region Navigation Properties

        [NotMapped]
        [JsonProperty("authors")]
        public ICollection<Author> Authors { get; set; }

        [NotMapped]
        [JsonProperty("series")]
        public ICollection<Series> Series { get; set; }

        [NotMapped]
        [JsonProperty("genres")]
        public ICollection<Genre> Genres { get; set; }

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

        [JsonProperty("brands_authors")]
        public ICollection<BrandsAuthor> BrandsAuthors { get; set; }

        [JsonProperty("brands_series")]
        public ICollection<BrandsSeries> BrandsSeries { get; set; }

        [JsonProperty("genres_brands")]
        public ICollection<GenresBrand> GenresBrands { get; set; }

        [JsonProperty("publishing_company")]
        public PublishingCompany PublishingCompany { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        #endregion

        #region Serialize Methods

        public bool ShouldSerializePublishingCompany() { return PublishingCompany != null; }
        public bool ShouldSerializeAvatar() { return Avatar != null; }
        public bool ShouldSerializeBooks() { return Books.Count > 0; }
        public bool ShouldSerializeAuthors() { return Authors.Count > 0; }
        public bool ShouldSerializeGenres() { return Genres.Count > 0; }
        public bool ShouldSerializeSeries() { return Series.Count > 0 ; }
        public bool ShouldSerializeBrandsAuthors() { return false; }
        public bool ShouldSerializeBrandsSeries() { return false; }
        public bool ShouldSerializeGenresBrands() { return false; }

        #endregion

    }

}
