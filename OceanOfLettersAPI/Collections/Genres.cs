using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Genres<T> : List<Genre>
    {

        public void Incorporate(List<Genre> genres)
        {

            Clear();

            foreach (Genre genre in genres)
            {
                Add(genre);
            }

        }

        public void Books()
        {

            ForEach(delegate (Genre genre)
            {

                foreach (GenresBook genresBook in genre.GenresBooks)
                    genre.Books.Add(genresBook.Book);

            });

        }

        public void Series()
        {

            ForEach(delegate (Genre genre)
            {

                foreach (GenresSeries genresSeries in genre.GenresSeries)
                    genre.Series.Add(genresSeries.Series);

            });

        }

        public void Brands()
        {

            ForEach(delegate (Genre genre)
            {

                foreach (GenresBrand genresBrand in genre.GenresBrands)
                    genre.Brands.Add(genresBrand.Brand);

            });

        }

        public void Authors()
        {

            ForEach(delegate (Genre genre)
            {

                foreach (GenresAuthor genresAuthor in genre.GenresAuthors)
                    genre.Authors.Add(genresAuthor.Author);

            });

        }

        public void PublishingCompanies()
        {

            ForEach(delegate (Genre genre)
            {

                foreach (GenresPublishingCompany genresPublishingCompany in genre.GenresPublishingCompanies)
                    genre.PublishingCompanies.Add(genresPublishingCompany.PublishingCompany);

            });

        }

    }

}
