using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Applications;
using OceanOfLettersAPI.Collections;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using OceanOfLettersAPI.Utilities;

namespace OceanOfLettersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> Index([FromServices] OceanOfLettersContext _context, [FromQuery]bool series, [FromQuery]bool books, [FromQuery]bool genres, [FromQuery]bool publishing_companies, [FromQuery]bool country, [FromQuery]bool brands, [FromQuery]int authors)
        {

            Response response = new Response();

            try
            {

                response = await new AuthorsApplication(_context).Index(series, books, genres, publishing_companies, country, brands, authors);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return Ok(response.Authors);

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor([FromServices] OceanOfLettersContext _context, int id)
        {
            var author = await _context.Author.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor([FromServices] OceanOfLettersContext _context, int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(_context, id))
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

        // POST: Authors
        [HttpPost]
        public async Task<ActionResult<Author>> Store([FromServices] OceanOfLettersContext _context, Author author)
        {

            Response response = new Response();
            Validations.Validations validation = new Validations.Validations();

            try
            {

                response = validation.Validate(author);

                if (validation.IsValid)
                {
                    response = await new AuthorsApplication(_context).Store(author);
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
                return CreatedAtAction("GetAuthor", new { id = author.Id }, response);

        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor([FromServices] OceanOfLettersContext _context, int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }

        private bool AuthorExists(OceanOfLettersContext _context, int id)
        {
            return _context.Author.Any(e => e.Id == id);
        }
    }
}
