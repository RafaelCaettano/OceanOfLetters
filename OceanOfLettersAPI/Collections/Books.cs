using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Books<T> : List<Book>
    {

        public void Incorporate(List<Book> books)
        {

            Clear();

            foreach (Book book in books)
            {
                Add(book);
            }

        }

        public void Genres()
        {

            ForEach(delegate (Book book)
            {

                foreach (GenresBook genresBook in book.GenresBooks)
                    book.Genres.Add(genresBook.Genre);

            });

        }

        public void Authors()
        {

            ForEach(delegate (Book book)
            {

                foreach (AuthorsBook authorsBook in book.AuthorsBooks)
                    book.Authors.Add(authorsBook.Author);

            });

        }

    }

}
