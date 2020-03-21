using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;

namespace OceanOfLettersAPI.Validations
{

    public class Validations
    {

        public bool IsValid { get; set; }

        public Response Validate(Author author)
        {

            IsValid = true;
            Response response = new Response();

            try
            {

                if (author.Name == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o nome do autor!";
                    IsValid = false;
                }

                if (author.Nationality == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a nacionalidade do autor!";
                    IsValid = false;
                }

                if (author.Birth == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a data de nascimento do autor!";
                    IsValid = false;
                }

                if (author.Biography == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a biografia do autor!";
                    IsValid = false;
                }

                if (author.CountryId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o país de origem do autor!";
                    IsValid = false;
                }

                if (author.ActivityPeriod == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o tempo de atividade do autor!";
                    IsValid = false;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
                IsValid = false;
            }

            return response;

        }

    }

}
