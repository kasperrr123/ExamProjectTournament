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
    [Route("api/Judges")]
    public class JudgesController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public JudgesController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Judges
        [HttpGet]
        public IEnumerable<TblJudge> GetTblJudge()
        {
            return _context.TblJudge;
        }

        // GET: api/Judges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblJudge([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudge = await _context.TblJudge.SingleOrDefaultAsync(m => m.FldJudgeLetter == id);

            if (tblJudge == null)
            {
                return NotFound();
            }

            return Ok(tblJudge);
        }

        // PUT: api/Judges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblJudge([FromRoute] string id, [FromBody] TblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblJudge.FldJudgeLetter)
            {
                return BadRequest();
            }

            _context.Entry(tblJudge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblJudgeExists(id))
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

        // POST: api/Judges
        [HttpPost]
        public async Task<IActionResult> PostTblJudge([FromBody] TblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblJudge.Add(tblJudge);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblJudgeExists(tblJudge.FldJudgeLetter))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblJudge", new { id = tblJudge.FldJudgeLetter }, tblJudge);
        }

        // DELETE: api/Judges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblJudge([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudge = await _context.TblJudge.SingleOrDefaultAsync(m => m.FldJudgeLetter == id);
            if (tblJudge == null)
            {
                return NotFound();
            }

            _context.TblJudge.Remove(tblJudge);
            await _context.SaveChangesAsync();

            return Ok(tblJudge);
        }

        private bool TblJudgeExists(string id)
        {
            return _context.TblJudge.Any(e => e.FldJudgeLetter == id);
        }
    }
}