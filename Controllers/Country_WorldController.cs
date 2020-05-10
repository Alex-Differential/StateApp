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
    public class Country_WorldController : ControllerBase
    {
        private readonly StateAppContext _context;

        public Country_WorldController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/Country_World
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country_World>>> GetCountry_Worlds()
        {
            return await _context.Country_Worlds.ToListAsync();
        }

        // GET: api/Country_World/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country_World>> GetCountry_World(int id)
        {
            var country_World = await _context.Country_Worlds.FindAsync(id);

            if (country_World == null)
            {
                return NotFound();
            }

            return country_World;
        }

        // PUT: api/Country_World/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry_World(int id, Country_World country_World)
        {
            if (id != country_World.CO_ID)
            {
                return BadRequest();
            }

            _context.Entry(country_World).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Country_WorldExists(id))
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

        // POST: api/Country_World
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country_World>> PostCountry_World(Country_World country_World)
        {
            _context.Country_Worlds.Add(country_World);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry_World", new { id = country_World.CO_ID }, country_World);
        }

        // DELETE: api/Country_World/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country_World>> DeleteCountry_World(int id)
        {
            var country_World = await _context.Country_Worlds.FindAsync(id);
            if (country_World == null)
            {
                return NotFound();
            }

            _context.Country_Worlds.Remove(country_World);
            await _context.SaveChangesAsync();

            return country_World;
        }

        private bool Country_WorldExists(int id)
        {
            return _context.Country_Worlds.Any(e => e.CO_ID == id);
        }
    }
}
