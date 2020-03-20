using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;

namespace OceanOfLettersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre([FromServices] OceanOfLettersContext _context)
        {
            return await _context.Genre.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre([FromServices] OceanOfLettersContext _context, int id)
        {
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre([FromServices] OceanOfLettersContext _context, int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(_context, id))
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

        // POST: api/Genres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre([FromServices] OceanOfLettersContext _context, Genre genre)
        {
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre([FromServices] OceanOfLettersContext _context, int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        private bool GenreExists(OceanOfLettersContext _context, int id)
        {
            return _context.Genre.Any(e => e.Id == id);
        }
    }
}
