using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Authors<T> : List<Author>
    {

        public void Incorporate(List<Author> authors)
        {

            Clear();

            foreach (Author author in authors)
            {
                Add(author);
            }

        }

        public void Books()
        {

            ForEach(delegate (Author author)
            {

                foreach (AuthorsBook authorsBook in author.AuthorsBooks)
                        author.Books.Add(authorsBook.Book);

            });

        }

        public void Series()
        {

            ForEach(delegate (Author author)
            {

                foreach (AuthorsSeries authorsSerie in author.AuthorsSeries)
                    author.Series.Add(authorsSerie.Series);

            });

        }

        public void PublishingCompanies()
        {

            ForEach(delegate (Author author)
            {

                foreach (PublishingCompaniesAuthor publishingCompaniesAuthor in author.PublishingCompaniesAuthors)
                    author.PublishingCompanies.Add(publishingCompaniesAuthor.PublishingCompany);

            });

        }

        public void Genres()
        {

            ForEach(delegate (Author author)
            {

                foreach (GenresAuthor genresAuthor in author.GenresAuthors)
                    author.Genres.Add(genresAuthor.Genre);

            });

        }

        public void Brands()
        {

            ForEach(delegate (Author author)
            {

                foreach (BrandsAuthor brandsAuthor in author.BrandsAuthors)
                    author.Brands.Add(brandsAuthor.Brand);

            });

        }

    }

}
