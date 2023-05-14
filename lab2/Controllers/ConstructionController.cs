using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        private readonly CarDealershipContext _context;

        public ConstructionController(CarDealershipContext context)
        {
            _context = context;
           
        }

        // GET: api/Blogs
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Construction>>> GetConstruction()
        {
            return await _context.Construction.ToListAsync();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Construction>> GetConstruction(int id)
        {
            var construction = await _context.Construction.FindAsync(id);

            if (construction == null)
            {
                return NotFound();
            }

            return construction;
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstruction(int id, Construction construction)
        {
            if (id != construction.Id)
            {
                return BadRequest();
            }

            _context.Entry(construction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionExists(id))
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

        // POST: api/Blogs
        [HttpPost("{id}/ChangeStock")]
        public async Task<ActionResult> ChangeStock(int id, [FromBody] int newValue)
        {
            var constr = _context.Construction.Where(i => i.Id == id).FirstOrDefault();
            constr.InStock = newValue;
            _context.Construction.Update(constr);
            _context.SaveChanges();
            return CreatedAtAction("GetConstruction", new { id = constr.Id }, constr);
        }

        [HttpPost]
        public async Task<ActionResult<Construction>> PostConstruction(ConstructionModel constr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Color col = _context.Color.Find(constr.Id_colour);
           int id = _context.Construction.OrderByDescending(i => i.Id).FirstOrDefault().Id+1;
            var c = new Construction
            {
                Id = id,
                Name = constr.Name,
                Id_model = constr.Id_model,
                Id_colour = constr.Id_colour,
                HorsePower = constr.HorsePower,
                EngineCapacity = constr.EngineCapacity,
                EngineType = constr.EngineType,
                Drive = constr.Drive,
                Transmission = constr.Transmission,
                InStock = constr.InStock,
                AutoModel = _context.AutoModel.Find(constr.Id_model),
                Color = _context.Color.Find(constr.Id_colour),
                Products = new List<Product>(),
            };
            _context.Construction.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstruction", new { id = constr.Id }, constr);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConstruction(int id)
        {
            var construction = await _context.Construction.FindAsync(id);
            if (construction == null)
            {
                return NotFound();
            }

            _context.Construction.Remove(construction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructionExists(int id)
        {
            return _context.Construction.Any(e => e.Id == id);
        }
    }
}
