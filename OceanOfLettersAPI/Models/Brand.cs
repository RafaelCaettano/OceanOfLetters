using Newtonsoft.Json;
using OceanOfLettersAPI.Models.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanOfLettersAPI.Models
{

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

        #endregion

    }

}
