using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
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

        private bool AuthorExists(string name)
        {
            return Context.Author.Any(e => e.Name == name);
        }

    }

}
