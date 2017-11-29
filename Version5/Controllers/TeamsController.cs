using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Version5.Models;

namespace Version5.Controllers
{
    [Produces("application/json")]
    [Route("api/Teams")]
    public class TeamsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public TeamsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public IEnumerable<TblTeam> GetTblTeam()
        {
            return _context.TblTeam;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblTeam([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamId == id);

            if (tblTeam == null)
            {
                return NotFound();
            }

            return Ok(tblTeam);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTeam([FromRoute] long id, [FromBody] TblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTeam.FldTeamId)
            {
                return BadRequest();
            }

            _context.Entry(tblTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTeamExists(id))
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

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTblTeam([FromBody] TblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblTeam.Add(tblTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTeam", new { id = tblTeam.FldTeamId }, tblTeam);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTeam([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamId == id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            _context.TblTeam.Remove(tblTeam);
            await _context.SaveChangesAsync();

            return Ok(tblTeam);
        }

        private bool TblTeamExists(long id)
        {
            return _context.TblTeam.Any(e => e.FldTeamId == id);
        }
    }
}