using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Domain;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Bets")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly DataContext _context;

        public BetsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Bets
        [HttpGet("{category}")]
        public async Task<ActionResult<IResponse>> GetBets(string category)
        {
            var bets = new List<Bet>()
            {
                new Bet("How will be the weather today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("Cloudy", 10, 11, 12), new BetOption("Sunny", 20, 22, 24), new BetOption("Stormy", 30, 33, 36) }),
                new Bet("How much will oil prices rise today? ", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("10.55", 10, 11, 12), new BetOption("20.30", 20, 22, 24), new BetOption("32.3", 30, 33, 36) }),
                new Bet("How many black-outs will EDESUR produce today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("10", 10, 11, 12), new BetOption("20", 20, 22, 24), new BetOption("30", 30, 33, 36) }),
                new Bet("How many childs will be born today?", 100, 100, "This bet is open", new List<BetOption>(){ new BetOption("100", 10, 11, 12), new BetOption("200", 20, 22, 24), new BetOption("300", 30, 33, 36) })
            };
            return Ok(new SuccessResponse(bets));
        }

        // GET: api/Bets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bet>> GetBet(int id)
        {
            var bet = await _context.Bets.FindAsync(id);

            if (bet == null)
            {
                return NotFound();
            }

            return bet;
        }

        // PUT: api/Bets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBet(int id, Bet bet)
        {
            if (id != bet.Id)
            {
                return BadRequest();
            }

            _context.Entry(bet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetExists(id))
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

        // POST: api/Bets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bet>> PostBet(Bet bet)
        {
            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBet", new { id = bet.Id }, bet);
        }

        // DELETE: api/Bets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bet>> DeleteBet(int id)
        {
            var bet = await _context.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();

            return bet;
        }

        private bool BetExists(int id)
        {
            return _context.Bets.Any(e => e.Id == id);
        }
    }
}
