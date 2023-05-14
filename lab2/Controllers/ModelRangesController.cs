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
    public class ModelRangesController : ControllerBase
    {
        private readonly CarDealershipContext _context;

        public ModelRangesController(CarDealershipContext context)
        {
            _context = context;
        }

        // GET: api/ModelRanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelRange>>> GetModelRange()
        {
          if (_context.ModelRange == null)
          {
              return NotFound();
          }
            return await _context.ModelRange.ToListAsync();
        }

        // GET: api/ModelRanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AutoModel>>> GetModelRange(int id)
        {
          if (_context.ModelRange == null)
          {
              return NotFound();
          }
            var modelRange = await _context.ModelRange.FindAsync(id);

            if (modelRange == null)
            {
                return NotFound();
            }

            return await _context.AutoModel.Where(i => i.Id_modelrange == modelRange.Id).ToListAsync();
        }

        // PUT: api/ModelRanges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelRange(int id, ModelRange modelRange)
        {
            if (id != modelRange.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelRange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelRangeExists(id))
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


        // POST: api/ModelRanges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelRange>> PostModelRange(ModelRange modelRange)
        {
          if (_context.ModelRange == null)
          {
              return Problem("Entity set 'CarDealershipContext.ModelRange'  is null.");
          }
            _context.ModelRange.Add(modelRange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelRange", new { id = modelRange.Id }, modelRange);
        }

        // DELETE: api/ModelRanges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelRange(int id)
        {
            if (_context.ModelRange == null)
            {
                return NotFound();
            }
            var modelRange = await _context.ModelRange.FindAsync(id);
            if (modelRange == null)
            {
                return NotFound();
            }

            _context.ModelRange.Remove(modelRange);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelRangeExists(int id)
        {
            return (_context.ModelRange?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
