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
    public class Polit_SystemController : ControllerBase
    {
        private readonly StateAppContext _context;

        public Polit_SystemController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/Polit_System
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Polit_System>>> GetPolit_Systems()
        {
            return await _context.Polit_Systems.ToListAsync();
        }

        // GET: api/Polit_System/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Polit_System>> GetPolit_System(int id)
        {
            var polit_System = await _context.Polit_Systems.FindAsync(id);

            if (polit_System == null)
            {
                return NotFound();
            }

            return polit_System;
        }

        // PUT: api/Polit_System/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolit_System(int id, Polit_System polit_System)
        {
            if (id != polit_System.PS_ID)
            {
                return BadRequest();
            }

            _context.Entry(polit_System).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Polit_SystemExists(id))
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

        // POST: api/Polit_System
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Polit_System>> PostPolit_System(Polit_System polit_System)
        {
            _context.Polit_Systems.Add(polit_System);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolit_System", new { id = polit_System.PS_ID }, polit_System);
        }

        // DELETE: api/Polit_System/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Polit_System>> DeletePolit_System(int id)
        {
            var polit_System = await _context.Polit_Systems.FindAsync(id);
            if (polit_System == null)
            {
                return NotFound();
            }

            _context.Polit_Systems.Remove(polit_System);
            await _context.SaveChangesAsync();

            return polit_System;
        }

        private bool Polit_SystemExists(int id)
        {
            return _context.Polit_Systems.Any(e => e.PS_ID == id);
        }
    }
}
