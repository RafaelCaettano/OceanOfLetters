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
    [Route("[publishing_companies]")]
    [ApiController]
    public class PublishingCompaniesController : ControllerBase
    {

        // GET: api/PublishingCompanies
        [HttpGet]
        public async Task<ActionResult<List<PublishingCompany>>> Index([FromServices] OceanOfLettersContext _context, [FromQuery]bool brands, [FromQuery]bool books, [FromQuery]bool authors, [FromQuery]bool genres, [FromQuery]bool series, [FromQuery]int publishing_companies)
        {

            Response response = new Response();

            try
            {

                response = await new PublishingCompaniesApplication(_context).Index(brands, books, authors, genres, series, publishing_companies);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return Ok(response.PublishingCompanies);

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
        public async Task<ActionResult<PublishingCompany>> Store([FromServices] OceanOfLettersContext _context, PublishingCompany publishingCompany)
        {

            Response response = new Response();
            Validations.Validations validation = new Validations.Validations();

            try
            {

                response = validation.Validate(publishingCompany);

                if (validation.IsValid)
                {
                    response = await new PublishingCompaniesApplication(_context).Store(publishingCompany);
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
                return CreatedAtAction("GetPublishingCompany", new { id = publishingCompany.Id }, response);

            //_context.PublishingCompany.Add(publishingCompany);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPublishingCompany", new { id = publishingCompany.Id }, publishingCompany);
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
