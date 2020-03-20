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
    public class PublishingCompaniesController : ControllerBase
    {

        // GET: api/PublishingCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingCompany>>> GetPublishingCompany([FromServices] OceanOfLettersContext _context)
        {
            return await _context.PublishingCompany.ToListAsync();
        }

        // GET: api/PublishingCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublishingCompany>> GetPublishingCompany([FromServices] OceanOfLettersContext _context, int id)
        {
            var publishingCompany = await _context.PublishingCompany.FindAsync(id);

            if (publishingCompany == null)
            {
                return NotFound();
            }

            return publishingCompany;
        }

        // PUT: api/PublishingCompanies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishingCompany([FromServices] OceanOfLettersContext _context, int id, PublishingCompany publishingCompany)
        {
            if (id != publishingCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishingCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingCompanyExists(_context, id))
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

        // POST: api/PublishingCompanies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PublishingCompany>> PostPublishingCompany([FromServices] OceanOfLettersContext _context, PublishingCompany publishingCompany)
        {
            _context.PublishingCompany.Add(publishingCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishingCompany", new { id = publishingCompany.Id }, publishingCompany);
        }

        // DELETE: api/PublishingCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublishingCompany>> DeletePublishingCompany([FromServices] OceanOfLettersContext _context, int id)
        {
            var publishingCompany = await _context.PublishingCompany.FindAsync(id);
            if (publishingCompany == null)
            {
                return NotFound();
            }

            _context.PublishingCompany.Remove(publishingCompany);
            await _context.SaveChangesAsync();

            return publishingCompany;
        }

        private bool PublishingCompanyExists(OceanOfLettersContext _context, int id)
        {
            return _context.PublishingCompany.Any(e => e.Id == id);
        }
    }
}
