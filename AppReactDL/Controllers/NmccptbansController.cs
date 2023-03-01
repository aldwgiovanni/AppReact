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
    public class NmccptbansController : ControllerBase
    {
        private readonly appreactdbContext _context;

        public NmccptbansController(appreactdbContext context)
        {
            _context = context;
        }

        // GET: api/Nmccptbans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nmccptban>>> GetNmccptbans()
        {
            return await _context.Nmccptbans.ToListAsync();
        }

        // GET: api/Nmccptbans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nmccptban>> GetNmccptban(int id)
        {
            var nmccptban = await _context.Nmccptbans.FindAsync(id);

            if (nmccptban == null)
            {
                return NotFound();
            }

            return nmccptban;
        }

        // PUT: api/Nmccptbans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNmccptban(int id, Nmccptban nmccptban)
        {
            if (id != nmccptban.IdBanque)
            {
                return BadRequest();
            }

            _context.Entry(nmccptban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NmccptbanExists(id))
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

        // POST: api/Nmccptbans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nmccptban>> PostNmccptban(Nmccptban nmccptban)
        {
            _context.Nmccptbans.Add(nmccptban);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NmccptbanExists(nmccptban.IdBanque))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNmccptban", new { id = nmccptban.IdBanque }, nmccptban);
        }

        // DELETE: api/Nmccptbans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNmccptban(int id)
        {
            var nmccptban = await _context.Nmccptbans.FindAsync(id);
            if (nmccptban == null)
            {
                return NotFound();
            }

            _context.Nmccptbans.Remove(nmccptban);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NmccptbanExists(int id)
        {
            return _context.Nmccptbans.Any(e => e.IdBanque == id);
        }
    }
}
