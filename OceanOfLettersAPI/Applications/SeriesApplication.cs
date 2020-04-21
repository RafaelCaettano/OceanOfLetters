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

    public class SeriesApplication
    {

        private readonly OceanOfLettersContext Context;

        public SeriesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool brands, bool books, bool authors, bool genres, bool publishingCompanies, int numSeries)
        {

            Response response = new Response();
            Serie<Series> series = new Serie<Series>();

            try
            {

                if (numSeries == 0)
                {

                    series.Incorporate(
                        await Context.Series.OrderBy(x => x.Name)
                                            .Include(x => x.Cover)
                                            .ToListAsync()
                    );

                }
                else
                {

                    series.Incorporate(
                        await Context.Series.OrderBy(x => x.Name)
                                            .Include(x => x.Cover)
                                            .Take(numSeries)
                                            .ToListAsync()
                    );

                }


                if (publishingCompanies)
                {

                    series.Union(
                        await Context.Series.Include(x => x.PublishingCompaniesSeries)
                                                .ThenInclude(y => y.PublishingCompany)
                                            .ToListAsync()
                    );

                    series.PublishingCompanies();

                }

                if (authors)
                {

                    series.Union(
                        await Context.Series.Include(x => x.AuthorsSeries)
                                                .ThenInclude(y => y.Author)
                                            .ToListAsync()
                    );

                    series.Authors();

                }

                if (genres)
                {

                    series.Union(
                        await Context.Series.Include(x => x.GenresSeries)
                                                .ThenInclude(y => y.Genre)
                                            .ToListAsync()
                    );

                    series.Genres();

                }

                if (brands)
                {

                    series.Union(
                        await Context.Series.Include(x => x.BrandsSeries)
                                                .ThenInclude(y => y.Brand)
                                            .ToListAsync()
                    );

                    series.Brands();

                }

                if (books)
                {

                    series.Union(
                        await Context.Series.Include(x => x.Books)
                                                .ThenInclude(y => y.Cover)
                                            .ToListAsync()
                    );

                }

                response.Series = series;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Store(Series series)
        {

            Response response = new Response
            {
                Serie = series
            };

            try
            {

                if (!SeriesExist(series.Name))
                {
                    Context.Add(series);
                    await Context.SaveChangesAsync();

                    response.Message = "Série cadastrada com sucesso!";
                }
                else
                {
                    response.Message = "Série já cadastrada!";
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

        private bool SeriesExist(string name)
        {
            return Context.Series.Any(e => e.Name == name);
        }

    }

}
