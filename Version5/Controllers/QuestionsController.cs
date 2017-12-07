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
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public QuestionsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<TblQuestions> GetTblQuestions()
        {
            return _context.TblQuestions;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblQuestions([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestions = await _context.TblQuestions.SingleOrDefaultAsync(m => m.FldQuestionsId == id);

            if (tblQuestions == null)
            {
                return NotFound();
            }

            return Ok(tblQuestions);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestions([FromRoute] long id, [FromBody] TblQuestions tblQuestions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuestions.FldQuestionsId)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionsExists(id))
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

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostTblQuestions([FromBody] TblQuestions tblQuestions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblQuestions.Add(tblQuestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuestions", new { id = tblQuestions.FldQuestionsId }, tblQuestions);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestions([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestions = await _context.TblQuestions.SingleOrDefaultAsync(m => m.FldQuestionsId == id);
            if (tblQuestions == null)
            {
                return NotFound();
            }

            _context.TblQuestions.Remove(tblQuestions);
            await _context.SaveChangesAsync();

            return Ok(tblQuestions);
        }

        private bool TblQuestionsExists(long id)
        {
            return _context.TblQuestions.Any(e => e.FldQuestionsId == id);
        }
    }
}