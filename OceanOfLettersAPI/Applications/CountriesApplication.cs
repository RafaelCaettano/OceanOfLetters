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

    public class CountriesApplication
    {

        private readonly OceanOfLettersContext Context;

        public CountriesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool language, bool books, bool authors, int numCountries)
        {

            Response response = new Response();
            Countries<Country> countries = new Countries<Country>();

            try
            {

                if (numCountries == 0)
                {

                    countries.Incorporate(
                        await Context.Country.OrderBy(x => x.Name)
                                             .ToListAsync()
                    );

                }
                else
                {

                    countries.Incorporate(
                        await Context.Country.OrderBy(x => x.Name)
                                             .Take(numCountries)
                                             .ToListAsync()
                    );

                }

                if (authors)
                {

                    countries.Union(
                        await Context.Country.Include(x => x.Authors)
                                             .ToListAsync()
                    );

                }

                if (books)
                {

                    countries.Union(
                        await Context.Country.Include(x => x.Books)
                                             .ToListAsync()
                    );

                }

                if (language)
                {

                    countries.Union(
                        await Context.Country.Include(x => x.Language)
                                             .ToListAsync()
                    );

                }

                response.Countries = countries;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Store(Country country)
        {

            Response response = new Response
            {
                Country = country
            };

            try
            {

                if (!CountryExist(country.Name))
                {
                    Context.Add(country);
                    await Context.SaveChangesAsync();

                    response.Message = "País cadastrado com sucesso!";
                }
                else
                {
                    response.Message = "País já cadastrado!";
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

        private bool CountryExist(string name)
        {
            return Context.Country.Any(e => e.Name == name);
        }

    }

}
