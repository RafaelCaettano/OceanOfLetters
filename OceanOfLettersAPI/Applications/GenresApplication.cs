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
