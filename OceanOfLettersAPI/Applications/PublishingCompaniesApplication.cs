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
