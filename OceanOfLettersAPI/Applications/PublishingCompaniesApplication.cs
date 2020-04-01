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

    public class PublishingCompaniesApplication
    {

        private readonly OceanOfLettersContext Context;

        public PublishingCompaniesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool brands, bool books, bool authors, bool genres, bool series, int numPublishingCompanies)
        {

            Response response = new Response();
            PublishingCompanies<PublishingCompany> publishingCompanies = new PublishingCompanies<PublishingCompany>();

            try
            {

                if (numPublishingCompanies == 0)
                {

                    publishingCompanies.Incorporate(
                        await Context.PublishingCompany.OrderBy(x => x.Name)
                                                       .ToListAsync()
                    );

                }
                else
                {

                    publishingCompanies.Incorporate(
                        await Context.PublishingCompany.OrderBy(x => x.Name)
                                                       .Take(numPublishingCompanies)
                                                       .ToListAsync()
                    );

                }


                if (series)
                {

                    publishingCompanies.Union(
                        await Context.PublishingCompany.Include(x => x.PublishingCompaniesSeries)
                                                            .ThenInclude(y => y.Series)
                                                       .ToListAsync()
                    );

                    publishingCompanies.Series();

                }

                if (authors)
                {

                    publishingCompanies.Union(
                        await Context.PublishingCompany.Include(x => x.PublishingCompaniesAuthors)
                                                            .ThenInclude(y => y.Author)
                                                       .ToListAsync()
                    );

                    publishingCompanies.Authors();

                }

                if (genres)
                {

                    publishingCompanies.Union(
                        await Context.PublishingCompany.Include(x => x.GenresPublishingCompanies)
                                                            .ThenInclude(y => y.Genre)
                                                       .ToListAsync()
                    );

                    publishingCompanies.Genres();

                }

                if (brands)
                {

                    publishingCompanies.Union(
                        await Context.PublishingCompany.Include(x => x.Brands)
                                                       .ToListAsync()
                    );

                }

                if (books)
                {

                    publishingCompanies.Union(
                        await Context.PublishingCompany.Include(x => x.Books)
                                           .ToListAsync()
                    );

                }

                response.PublishingCompanies = publishingCompanies;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Store(PublishingCompany publishingCompany)
        {

            Response response = new Response
            {
                PublishingCompany = publishingCompany
            };

            try
            {

                if (!PublishingCompanyExist(publishingCompany.Name))
                {
                    Context.Add(publishingCompany);
                    await Context.SaveChangesAsync();

                    response.Message = "Editora cadastrada com sucesso!";
                }
                else
                {
                    response.Message = "Editora já cadastrada!";
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

        private bool PublishingCompanyExist(string name)
        {
            return Context.PublishingCompany.Any(e => e.Name == name);
        }

    }

}
