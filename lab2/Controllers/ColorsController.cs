using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        private readonly CarDealershipContext _context;

        public ColorsController(CarDealershipContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColor()
        {
            if (_context.Color == null)
            {
                return NotFound();
            }
            var acc = await _context.Color.ToListAsync();
            return acc;
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            if (_context.Color == null)
            {
                return NotFound();
            }
            var colors = await _context.Color.FindAsync(id);

            if (colors == null)
            {
                return NotFound();
            }

            return colors;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color colors)
        {
            if (id != colors.Id)
            {
                return BadRequest();
            }

            _context.Entry(colors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color colors)
        {
            if (_context.Color == null)
            {
                return Problem("Entity set 'CarDealershipContext.Color'  is null.");
            }
            _context.Color.Add(colors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = colors.Id }, colors);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (_context.Color == null)
            {
                return NotFound();
            }
            var colors = await _context.Color.FindAsync(id);
            if (colors == null)
            {
                return NotFound();
            }

            _context.Color.Remove(colors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return (_context.Color?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
