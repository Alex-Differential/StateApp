using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateApp.Models;

namespace StateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EconomiesController : ControllerBase
    {
        private readonly StateAppContext _context;

        public EconomiesController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/Economies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Economy>>> GetEconomies()
        {
            return await _context.Economies.ToListAsync();
        }

        // GET: api/Economies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Economy>> GetEconomy(int id)
        {
            var economy = await _context.Economies.FindAsync(id);

            if (economy == null)
            {
                return NotFound();
            }

            return economy;
        }

        // PUT: api/Economies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEconomy(int id, Economy economy)
        {
            if (id != economy.EC_ID)
            {
                return BadRequest();
            }

            _context.Entry(economy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomyExists(id))
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

        // POST: api/Economies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Economy>> PostEconomy(Economy economy)
        {
            _context.Economies.Add(economy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEconomy", new { id = economy.EC_ID }, economy);
        }

        // DELETE: api/Economies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Economy>> DeleteEconomy(int id)
        {
            var economy = await _context.Economies.FindAsync(id);
            if (economy == null)
            {
                return NotFound();
            }

            _context.Economies.Remove(economy);
            await _context.SaveChangesAsync();

            return economy;
        }

        private bool EconomyExists(int id)
        {
            return _context.Economies.Any(e => e.EC_ID == id);
        }
    }
}
