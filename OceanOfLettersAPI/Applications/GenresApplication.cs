using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Collections;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class GenresApplication
    {

        private readonly OceanOfLettersContext Context;

        public GenresApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool books, bool authors, bool publishingCompanies, bool series, bool brands, int numGenres)
        {

            Response response = new Response();
            Genres<Genre> genres = new Genres<Genre>();

            try
            {

                if (numGenres == 0)
                {

                    genres.Incorporate(
                        await Context.Genre.OrderBy(x => x.Name)
                                           .ToListAsync()
                    );

                }
                else
                {

                    genres.Incorporate(
                        await Context.Genre.OrderBy(x => x.Name)
                                           .Take(numGenres)
                                           .ToListAsync()
                    );

                }


                if (series)
                {

                    genres.Union(
                        await Context.Genre.Include(x => x.GenresSeries)
                                                .ThenInclude(y => y.Series)
                                           .ToListAsync()
                    );

                    genres.Series();

                }

                if (books)
                {

                    genres.Union(
                        await Context.Genre.Include(x => x.GenresBooks)
                                                .ThenInclude(y => y.Book)
                                           .ToListAsync()
                    );

                    genres.Books();

                }

                if (authors)
                {

                    genres.Union(
                        await Context.Genre.Include(x => x.GenresAuthors)
                                                .ThenInclude(y => y.Genre)
                                           .ToListAsync()
                    );

                    genres.Authors();

                }

                if (publishingCompanies)
                {

                    genres.Union(
                        await Context.Genre.Include(x => x.GenresPublishingCompanies)
                                                .ThenInclude(y => y.PublishingCompany)
                                           .ToListAsync()
                    );

                    genres.PublishingCompanies();

                }

                if (brands)
                {

                    genres.Union(
                        await Context.Genre.Include(x => x.GenresBrands)
                                                .ThenInclude(y => y.Brand)
                                           .ToListAsync()
                    );

                    genres.Brands();

                }

                response.Genres = genres;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Store(Genre genre)
        {

            Response response = new Response
            {
                Genre = genre
            };

            try
            {

                if (!GenreExist(genre.Name))
                {
                    Context.Add(genre);
                    await Context.SaveChangesAsync();

                    response.Message = "Gênero cadastrado com sucesso!";
                }
                else
                {
                    response.Message = "Gênero já cadastrado";
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

        private bool GenreExist(string name)
        {
            return Context.Genre.Any(e => e.Name == name);
        }

    }

}
