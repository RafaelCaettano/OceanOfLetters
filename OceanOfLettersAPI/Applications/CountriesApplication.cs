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
