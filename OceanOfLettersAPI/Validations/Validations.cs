using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;

namespace OceanOfLettersAPI.Validations
{

    public static class Validations
    {

        public static Response Validate(Author author)
        {

            Response response = new Response();

            try
            {

                if (author.Name == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o nome do autor!";
                }

                if (author.Nationality == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a nacionalidade do autor!";
                }

                if (author.Birth == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a data de nascimento do autor!";
                }

                if (author.Biography == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a biografia do autor!";
                }

                if (author.CountryId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o país de origem do autor!";
                }

                if (author.ActivityPeriod == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o tempo de atividade do autor!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

    }

}
