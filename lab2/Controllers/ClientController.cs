using BLL.Interface;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDbCrud _context;

        public ClientController(IDbCrud context)
        {
            _context = context;
        }

        // GET: api/Clients

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientPurchaseModel>>> GetClient()
        {
            
            return await Task.Run(()=>_context.GetAllClientPurchaseModels());
        }

        
        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientPurchaseModel>> PostClientPurchaseModel([FromBody]ClientPurchaseModel clientPurchase)
        {
            _context.CreateClientPurch(clientPurchase);
              return CreatedAtAction("GetClientPurch", new { id = clientPurchase.Id }, clientPurchase);

            return NoContent();
        }
    }
}
