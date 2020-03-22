using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class BrandsApplication
    {

        private readonly OceanOfLettersContext Context;

        public BrandsApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Store(Brand brand)
        {

            Response response = new Response
            {
                Brand = brand
            };

            try
            {

                if (!BrandExists(brand.Name))
                {
                    Context.Add(brand);
                    await Context.SaveChangesAsync();

                    response.Message = "Marca de editora cadastrada com sucesso!";
                }
                else
                {
                    response.Message = "Marca de editora já cadastrada";
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

        private bool BrandExists(string name)
        {
            return Context.Brand.Any(e => e.Name == name);
        }

    }

}
