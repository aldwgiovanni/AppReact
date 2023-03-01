using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppReactBL.Models;

namespace AppReactDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NmcBanquesController : ControllerBase
    {
        private readonly appreactdbContext _context;

        public NmcBanquesController(appreactdbContext context)
        {
            _context = context;
        }

        // GET: api/NmcBanques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NmcBanque>>> GetNmcBanques()
        {
            return await _context.NmcBanques.ToListAsync();
        }

        // GET: api/NmcBanques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NmcBanque>> GetNmcBanque(int id)
        {
            var nmcBanque = await _context.NmcBanques.FindAsync(id);

            if (nmcBanque == null)
            {
                return NotFound();
            }

            return nmcBanque;
        }

        // PUT: api/NmcBanques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNmcBanque(int id, NmcBanque nmcBanque)
        {
            if (id != nmcBanque.IdBanque)
            {
                return BadRequest();
            }

            _context.Entry(nmcBanque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NmcBanqueExists(id))
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

        // POST: api/NmcBanques/Create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NmcBanque>> PostNmcBanque(NmcBanque nmcBanque)
        {
            _context.NmcBanques.Add(nmcBanque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostNmcBanque), nmcBanque);
        }

        // DELETE: api/NmcBanques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNmcBanque(int id)
        {
            var nmcBanque = await _context.NmcBanques.FindAsync(id);
            if (nmcBanque == null)
            {
                return NotFound();
            }

            _context.NmcBanques.Remove(nmcBanque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NmcBanqueExists(int id)
        {
            return _context.NmcBanques.Any(e => e.IdBanque == id);
        }
    }
}
