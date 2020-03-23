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
