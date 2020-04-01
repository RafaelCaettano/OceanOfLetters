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
    public class BrandsController : ControllerBase
    {

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<List<Brand>>> Index([FromServices] OceanOfLettersContext _context, [FromQuery]bool publishing_company, [FromQuery]bool books, [FromQuery]bool genres, [FromQuery]bool authors, [FromQuery]bool series, [FromQuery]int brands)
        {

            Response response = new Response();

            try
            {

                response = await new BrandsApplication(_context).Index(publishing_company, books, authors, genres, series, brands);

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

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand([FromServices] OceanOfLettersContext _context, int id)
        {
            var brand = await _context.Brand.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand([FromServices] OceanOfLettersContext _context, int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(_context, id))
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

        // POST: api/Brands
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Brand>> Store([FromServices] OceanOfLettersContext _context, Brand brand)
        {

            Response response = new Response();
            Validations.Validations validation = new Validations.Validations();

            try
            {

                response = validation.Validate(brand);

                if (validation.IsValid)
                {
                    response = await new BrandsApplication(_context).Store(brand);
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
                return CreatedAtAction("GetBrand", new { id = brand.Id }, response);

            //_context.Brand.Add(brand);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand([FromServices] OceanOfLettersContext _context, int id)
        {
            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();

            return brand;
        }

        private bool BrandExists(OceanOfLettersContext _context, int id)
        {
            return _context.Brand.Any(e => e.Id == id);
        }
    }
}
