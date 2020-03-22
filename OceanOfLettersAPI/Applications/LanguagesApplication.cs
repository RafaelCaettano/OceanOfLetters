using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class LanguagesApplication
    {

        private readonly OceanOfLettersContext Context;

        public LanguagesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Store(Language language)
        {

            Response response = new Response
            {
                Language = language
            };

            try
            {

                if (!LanguageExist(language.Name))
                {
                    Context.Add(language);
                    await Context.SaveChangesAsync();

                    response.Message = "Idioma cadastrado com sucesso!";
                }
                else
                {
                    response.Message = "Idioma já cadastrado";
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

        private bool LanguageExist(string name)
        {
            return Context.Language.Any(e => e.Name == name);
        }

    }

}
