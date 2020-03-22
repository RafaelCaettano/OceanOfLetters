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

        public Response Validate(Book book)
        {

            IsValid = true;
            Response response = new Response();

            try
            {

                if (book.Name == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o nome do Livro!";
                    IsValid = false;
                }

                if (book.Launch == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a data de lançamento do livro!";
                    IsValid = false;
                }

                if (book.Pages == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o número de páginas do livro";
                    IsValid = false;
                }

                if (book.Synopsis == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a sinopse do livro!";
                    IsValid = false;
                }

                if (book.Format == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o formato do livro!";
                    IsValid = false;
                }

                if (book.Isbn == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o ISBN do livro";
                    IsValid = false;
                }

                if (book.LanguageId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o idioma do livro!";
                    IsValid = false;
                }

                if (book.CountryId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o país de origem do livro!";
                    IsValid = false;
                }

                if (book.PublishingCompanyId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a editora do livro!";
                    IsValid = false;
                }

                if (book.AuthorsBook.Count == 0)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o(a) autor(a) do livro!";
                    IsValid = false;
                }

                if (book.GenresBooks.Count == 0)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o gênero do livro!";
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

        public Response Validate(Brand brand)
        {

            IsValid = true;
            Response response = new Response();

            try
            {

                if (brand.Name == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o nome da marca de editora!";
                    IsValid = false;
                }

                if (brand.PublishingCompanyId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a editora da marca de editora!";
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

        public Response Validate(Country country)
        {

            IsValid = true;
            Response response = new Response();

            try
            {

                if (country.Name == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira o nome do país!";
                    IsValid = false;
                }

                if (country.LanguageId == null)
                {
                    response.BadRequest = true;
                    response.Message = "Insira a lígua principal do país!";
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
