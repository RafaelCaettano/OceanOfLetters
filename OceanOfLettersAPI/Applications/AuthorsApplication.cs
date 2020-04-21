using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using OceanOfLettersAPI.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class AuthorsApplication
    {

        private readonly OceanOfLettersContext Context;

        public AuthorsApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Store(Author author)
        {

            Response response = new Response
            {
                Author = author
            };

            try
            {

                if (!AuthorExists(author.Name))
                {

                    Context.Add(author);
                    await Context.SaveChangesAsync();

                    response.Message = "Autor cadastrado com sucesso!";

                }
                else
                {
                    response.Message = "Autor já cadastrado!";
                    response.BadRequest = true;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Index(bool series, bool books, bool genres, bool publishingCompanies, bool country, bool brands, int numAuthors)
        {

            Response response = new Response();
            Authors<Author> authors = new Authors<Author>();

            try
            {

                if (numAuthors == 0)
                {

                    authors.Incorporate(
                        await Context.Author.OrderBy(x => x.Name)
                                            .Include(x => x.Avatar)
                                            .ToListAsync()
                    );

                }
                else
                {

                    authors.Incorporate(
                        await Context.Author.OrderBy(x => x.Name)
                                            .Include(x => x.Avatar)
                                            .Take(numAuthors)
                                            .ToListAsync()
                    );

                }


                if (series)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.AuthorsSeries)
                                                .ThenInclude(y => y.Series)
                                            .ToListAsync()
                    );

                    authors.Series();

                }

                if (books)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.AuthorsBooks)
                                                .ThenInclude(y => y.Book)
                                                    .ThenInclude(y => y.Cover)
                                            .ToListAsync()
                    );

                    authors.Books();

                }

                if (genres)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.GenresAuthors)
                                                .ThenInclude(y => y.Genre)
                                            .ToListAsync()
                    );

                    authors.Genres();

                }

                if (publishingCompanies)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.PublishingCompaniesAuthors)
                                                .ThenInclude(y => y.PublishingCompany)
                                            .ToListAsync()
                    );

                    authors.PublishingCompanies();

                }

                if (brands)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.BrandsAuthors)
                                                .ThenInclude(y => y.Brand)
                                            .ToListAsync()
                    );

                    authors.Brands();

                }

                if (country)
                {

                    authors.Union(
                        await Context.Author.Include(x => x.Country)
                                            .ToListAsync()
                    );

                }

                response.Authors = authors;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        private bool AuthorExists(string name)
        {
            return Context.Author.Any(e => e.Name == name);
        }

    }

}
