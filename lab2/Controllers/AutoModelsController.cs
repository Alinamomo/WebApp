using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using BLL.Models;
using DAL.Interface;

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoModelsController : ControllerBase
    {
        private readonly IDbRepos db;

        public AutoModelsController(IDbRepos db_c)
        {
            db = db_c;
        }

        // GET: api/AutoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoModel>>> GetAutoModel()
        {
          if (db.AutoModels == null)
          {
              return NotFound();
          }
            return await Task.Run(() => db.AutoModels.GetList());
        }

        // GET: api/AutoModelss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ConstructionModel>>> GetAutoModel(int id)
        {
          if (db.AutoModels == null)
          {
              return NotFound();
          }
            var autoModel = db.AutoModels.GetItem(id);
            var constrs = db.Constructions.GetList().Where(i => i.Id_model == autoModel.Id).ToList();

            if (autoModel == null)
            {
                return NotFound();
            }

           return await Task.Run(() =>constrs.Select(i => new ConstructionModel(i, db)).ToList());
        }

        // PUT: api/AutoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutoModel(int id, AutoModel autoModel)
        {
        //    if (id != autoModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(autoModel).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AutoModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

            return NoContent();
        }

        // POST: api/AutoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutoModel>> PostAutoModel(AutoModel autoModel)
        {
          //if (db.AutoModels == null)
          //{
          //    return Problem("Entity set 'CarDealershipContext.AutoModel'  is null.");
          //}
          //  db.AutoModels.Create(autoModel);
          //  await db.SaveChangesAsync();

          //  return CreatedAtAction("GetAutoModel", new { id = autoModel.Id }, autoModel);

            return NoContent();
        }

        // DELETE: api/AutoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoModel(int id)
        {
            //if (db.AutoModels == null)
            //{
            //    return NotFound();
            //}
            //var autoModel = await db.AutoModels.FindAsync(id);
            //if (autoModel == null)
            //{
            //    return NotFound();
            //}

            //db.AutoModels.Remove(autoModel);
            //await db.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoModelExists(int id)
        {
            return false;// (db.AutoModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
