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

    public class LanguagesApplication
    {

        private readonly OceanOfLettersContext Context;

        public LanguagesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool countries, bool books, int numLanguages)
        {

            Response response = new Response();
            Languages<Language> languages = new Languages<Language>();

            try
            {

                if (numLanguages == 0)
                {

                    languages.Incorporate(
                        await Context.Language.OrderBy(x => x.Name)
                                              .ToListAsync()
                    );

                }
                else
                {

                    languages.Incorporate(
                        await Context.Language.OrderBy(x => x.Name)
                                              .Take(numLanguages)
                                              .ToListAsync()
                    );

                }

                if (books)
                {

                    languages.Union(
                        await Context.Language.Include(x => x.Books)
                                              .ToListAsync()
                    );

                }

                if (countries)
                {

                    languages.Union(
                        await Context.Language.Include(x => x.Countries)
                                              .ToListAsync()
                    );

                }

                response.Languages = languages;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

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
