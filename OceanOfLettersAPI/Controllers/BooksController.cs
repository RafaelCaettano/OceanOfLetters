using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Applications;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;

namespace OceanOfLettersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Index([FromServices] OceanOfLettersContext _context, [FromQuery]bool series, [FromQuery]bool authors, [FromQuery]bool genres, [FromQuery]bool language, [FromQuery]bool country, [FromQuery]bool publishing_company, [FromQuery]bool brand, [FromQuery]int books)
        {

            Response response = new Response();

            try
            {

                response = await new BooksApplication(_context).Index(series, authors, genres, language, country, publishing_company, brand, books);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return Ok(response);

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook([FromServices] OceanOfLettersContext _context, int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromServices] OceanOfLettersContext _context, int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(_context, id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> Store([FromServices] OceanOfLettersContext _context, Book book)
        {

            Response response = new Response();
            Validations.Validations validation = new Validations.Validations();

            try
            {

                response = validation.Validate(book);

                if (validation.IsValid)
                {

                    //foreach (AuthorsBook authorBook in book.AuthorsBook)
                    //{
                    //    if (!new AuthorApplication(_context).ExistAuthorById(authorBook.AuthorId))
                    //    {
                    //        repost.Message = "Autor não cadastrado!";
                    //        return BadRequest(repost);
                    //    }
                    //}

                    //if (!new PublishingCompanyApplication(_context).ExistPublishingCompany(book.PublishingCompanyId))
                    //{
                    //    repost.Message = "Editora não cadastrada!";
                    //    return BadRequest(repost);
                    //}

                    //if (book.SeriesId != null)
                    //{
                    //    if (!new SeriesApplication(_context).ExistSeries(book.SeriesId))
                    //    {
                    //        repost.Message = "Série não cadastrada!";
                    //        return BadRequest(repost);
                    //    }
                    //}

                    //if (book.BrandId != null)
                    //{
                    //    if (!new BrandApplication(_context).ExistBrand(book.BrandId))
                    //    {
                    //        repost.Message = "Marca de editora não cadastrada!";
                    //        return BadRequest(repost);
                    //    }
                    //}

                    //if (!new CountryApplication(_context).ExistCountry(book.CountryId))
                    //{
                    //    repost.Message = "País não cadastrado!";
                    //    return BadRequest(repost);
                    //}

                    //if (new LanguageApplication(_context).ExistLanguage(book.LanguageId) == false)
                    //{
                    //    repost.Message = "Idioma não cadastrado!";
                    //    return BadRequest(repost);
                    //}

                    //foreach (GenresBook genresBook in book.GenresBooks)
                    //{
                    //    if (!new GenreApplication(_context).ExistGenre(genresBook.GenreId))
                    //    {
                    //        repost.Message = "Gênero não cadastrado!";
                    //        return BadRequest(repost);
                    //    }
                    //}

                    response = await new BooksApplication(_context).Store(book);

                }
                else
                {
                    response.BadRequest = true;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return CreatedAtAction("GetBook", new { id = book.Id }, response);

            //_context.Book.Add(book);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook([FromServices] OceanOfLettersContext _context, int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(OceanOfLettersContext _context, int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
