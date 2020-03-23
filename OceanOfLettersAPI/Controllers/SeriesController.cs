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
    public class SeriesController : ControllerBase
    {

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetSeries([FromServices] OceanOfLettersContext _context)
        {
            return await _context.Series.ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeries([FromServices] OceanOfLettersContext _context, int id)
        {
            var series = await _context.Series.FindAsync(id);

            if (series == null)
            {
                return NotFound();
            }

            return series;
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries([FromServices] OceanOfLettersContext _context, int id, Series series)
        {
            if (id != series.Id)
            {
                return BadRequest();
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(_context, id))
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

        // POST: api/Series
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Series>> PostSeries([FromServices] OceanOfLettersContext _context, Series series)
        {

            Response response = new Response();
            Validations.Validations validation = new Validations.Validations();

            try
            {

                response = validation.Validate(series);

                if (validation.IsValid)
                {
                    response = await new SeriesApplication(_context).Store(series);
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
                return CreatedAtAction("GetSeries", new { id = series.Id }, response);


            //_context.Series.Add(series);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSeries", new { id = series.Id }, series);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Series>> DeleteSeries([FromServices] OceanOfLettersContext _context, int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return series;
        }

        private bool SeriesExists(OceanOfLettersContext _context, int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
