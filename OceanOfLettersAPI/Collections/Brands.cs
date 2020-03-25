using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Brands<T> : List<Brand>
    {

        public void Incorporate(List<Brand> brands)
        {

            Clear();

            foreach (Brand brand in brands)
            {
                Add(brand);
            }

        }

        public void Genres()
        {

            ForEach(delegate (Brand brand)
            {

                foreach (GenresBrand genresBrand in brand.GenresBrands)
                    brand.Genres.Add(genresBrand.Genre);

            });

        }

        public void Authors()
        {

            ForEach(delegate (Brand brand)
            {

                foreach (BrandsAuthor brandsAuthor in brand.BrandsAuthors)
                    brand.Authors.Add(brandsAuthor.Author);

            });

        }

        public void Series()
        {

            ForEach(delegate (Brand brand)
            {

                foreach (BrandsSeries brandsSeries in brand.BrandsSeries)
                    brand.Series.Add(brandsSeries.Series);

            });

        }

    }

}
