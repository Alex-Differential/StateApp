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
    public class GovermentsController : ControllerBase
    {
        private readonly StateAppContext _context;

        public GovermentsController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/Goverments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goverment>>> GetGoverments()
        {
            return await _context.Goverments.ToListAsync();
        }

        // GET: api/Goverments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goverment>> GetGoverment(int id)
        {
            var goverment = await _context.Goverments.FindAsync(id);

            if (goverment == null)
            {
                return NotFound();
            }

            return goverment;
        }

        // PUT: api/Goverments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoverment(int id, Goverment goverment)
        {
            if (id != goverment.GV_ID)
            {
                return BadRequest();
            }

            _context.Entry(goverment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovermentExists(id))
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

        // POST: api/Goverments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Goverment>> PostGoverment(Goverment goverment)
        {
            _context.Goverments.Add(goverment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoverment", new { id = goverment.GV_ID }, goverment);
        }

        // DELETE: api/Goverments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goverment>> DeleteGoverment(int id)
        {
            var goverment = await _context.Goverments.FindAsync(id);
            if (goverment == null)
            {
                return NotFound();
            }

            _context.Goverments.Remove(goverment);
            await _context.SaveChangesAsync();

            return goverment;
        }

        private bool GovermentExists(int id)
        {
            return _context.Goverments.Any(e => e.GV_ID == id);
        }
    }
}
