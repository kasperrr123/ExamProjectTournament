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
    [Route("api/Tournaments")]
    public class TournamentsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public TournamentsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public IEnumerable<TblTournament> GetTblTournament()
        {
            return _context.TblTournament;
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTournament = await _context.TblTournament.SingleOrDefaultAsync(m => m.FldTournamentId == id);

            if (tblTournament == null)
            {
                return NotFound();
            }

            return Ok(tblTournament);
        }

        // PUT: api/Tournaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTournament([FromRoute] int id, [FromBody] TblTournament tblTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTournament.FldTournamentId)
            {
                return BadRequest();
            }

            _context.Entry(tblTournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTournamentExists(id))
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

        // POST: api/Tournaments
        [HttpPost]
        public async Task<IActionResult> PostTblTournament([FromBody] TblTournament tblTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblTournament.Add(tblTournament);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblTournamentExists(tblTournament.FldTournamentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblTournament", new { id = tblTournament.FldTournamentId }, tblTournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTournament = await _context.TblTournament.SingleOrDefaultAsync(m => m.FldTournamentId == id);
            if (tblTournament == null)
            {
                return NotFound();
            }

            _context.TblTournament.Remove(tblTournament);
            await _context.SaveChangesAsync();

            return Ok(tblTournament);
        }

        private bool TblTournamentExists(int id)
        {
            return _context.TblTournament.Any(e => e.FldTournamentId == id);
        }
    }
}