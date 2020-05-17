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
    public class State_BoardController : ControllerBase
    {
        private readonly StateAppContext _context;

        public State_BoardController(StateAppContext context)
        {
            _context = context;
        }

        // GET: api/State_Board
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State_Board>>> GetState_Boards()
        {
            return await _context.State_Boards.ToListAsync();
        }

        // GET: api/State_Board/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State_Board>> GetState_Board(int id)
        {
            var state_Board = await _context.State_Boards.FindAsync(id);

            if (state_Board == null)
            {
                return NotFound();
            }

            return state_Board;
        }

        // PUT: api/State_Board/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState_Board(int id, State_Board state_Board)
        {
            if (id != state_Board.SD_ID)
            {
                return BadRequest();
            }

            _context.Entry(state_Board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!State_BoardExists(id))
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

        // POST: api/State_Board
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<State_Board>> PostState_Board(State_Board state_Board)
        {
            _context.State_Boards.Add(state_Board);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetState_Board", new { id = state_Board.SD_ID }, state_Board);
            return CreatedAtAction(nameof(GetState_Board), new { id = state_Board.SD_ID }, state_Board);
        }

        // DELETE: api/State_Board/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<State_Board>> DeleteState_Board(int id)
        {
            var state_Board = await _context.State_Boards.FindAsync(id);
            if (state_Board == null)
            {
                return NotFound();
            }

            _context.State_Boards.Remove(state_Board);
            await _context.SaveChangesAsync();

            return state_Board;
        }

        private bool State_BoardExists(int id)
        {
            return _context.State_Boards.Any(e => e.SD_ID == id);
        }
    }
}
