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
    public class Econ_Cos_InfoController : ControllerBase
    {
        private readonly StateAppContext _context;

        public Econ_Cos_InfoController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/Econ_Cos_Info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Econ_Cos_Info>>> GetEcon_Cos_Infos()
        {
            return await _context.Econ_Cos_Infos.ToListAsync();
        }

        // GET: api/Econ_Cos_Info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Econ_Cos_Info>> GetEcon_Cos_Info(int id)
        {
            var econ_Cos_Info = await _context.Econ_Cos_Infos.FindAsync(id);

            if (econ_Cos_Info == null)
            {
                return NotFound();
            }

            return econ_Cos_Info;
        }

        // PUT: api/Econ_Cos_Info/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcon_Cos_Info(int id, Econ_Cos_Info econ_Cos_Info)
        {
            if (id != econ_Cos_Info.EI_ID)
            {
                return BadRequest();
            }

            _context.Entry(econ_Cos_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Econ_Cos_InfoExists(id))
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

        // POST: api/Econ_Cos_Info
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Econ_Cos_Info>> PostEcon_Cos_Info(Econ_Cos_Info econ_Cos_Info)
        {
            _context.Econ_Cos_Infos.Add(econ_Cos_Info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcon_Cos_Info", new { id = econ_Cos_Info.EI_ID }, econ_Cos_Info);
        }

        // DELETE: api/Econ_Cos_Info/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Econ_Cos_Info>> DeleteEcon_Cos_Info(int id)
        {
            var econ_Cos_Info = await _context.Econ_Cos_Infos.FindAsync(id);
            if (econ_Cos_Info == null)
            {
                return NotFound();
            }

            _context.Econ_Cos_Infos.Remove(econ_Cos_Info);
            await _context.SaveChangesAsync();

            return econ_Cos_Info;
        }

        private bool Econ_Cos_InfoExists(int id)
        {
            return _context.Econ_Cos_Infos.Any(e => e.EI_ID == id);
        }
    }
}
