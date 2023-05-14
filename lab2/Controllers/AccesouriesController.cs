using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesouriesController : ControllerBase
    {
        private readonly CarDealershipContext _context;

        public AccesouriesController(CarDealershipContext context)
        {
            _context = context;
        }

        // GET: api/Accesouries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accesouries>>> GetAccesouries()
        {
            if (_context.Accesouries == null)
            {
                return NotFound();
            }
            var acc = await _context.Accesouries.ToListAsync();
            return acc;
        }

        // GET: api/Accesouries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accesouries>> GetAccesouries(int id)
        {
            if (_context.Accesouries == null)
            {
                return NotFound();
            }
            var accesouries = await _context.Accesouries.FindAsync(id);

            if (accesouries == null)
            {
                return NotFound();
            }

            return accesouries;
        }

        // PUT: api/Accesouries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccesouries(int id, Accesouries accesouries)
        {
            if (id != accesouries.Id)
            {
                return BadRequest();
            }

            _context.Entry(accesouries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesouriesExists(id))
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

        // POST: api/Accesouries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accesouries>> PostAccesouries(Accesouries accesouries)
        {
            if (_context.Accesouries == null)
            {
                return Problem("Entity set 'CarDealershipContext.Accesouries'  is null.");
            }
            _context.Accesouries.Add(accesouries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccesouries", new { id = accesouries.Id }, accesouries);
        }

        // DELETE: api/Accesouries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccesouries(int id)
        {
            if (_context.Accesouries == null)
            {
                return NotFound();
            }
            var accesouries = await _context.Accesouries.FindAsync(id);
            if (accesouries == null)
            {
                return NotFound();
            }

            _context.Accesouries.Remove(accesouries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccesouriesExists(int id)
        {
            return (_context.Accesouries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
