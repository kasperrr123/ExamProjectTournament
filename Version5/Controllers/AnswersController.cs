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
    [Route("api/Answers")]
    public class AnswersController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public AnswersController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public IEnumerable<TblAnswer> GetTblAnswer()
        {
            return _context.TblAnswer;
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblAnswer = await _context.TblAnswer.SingleOrDefaultAsync(m => m.FldAnswerId == id);

            if (tblAnswer == null)
            {
                return NotFound();
            }

            return Ok(tblAnswer);
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAnswer([FromRoute] long id, [FromBody] TblAnswer tblAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAnswer.FldAnswerId)
            {
                return BadRequest();
            }

            _context.Entry(tblAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAnswerExists(id))
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

        // POST: api/Answers
        [HttpPost]
        public async Task<IActionResult> PostTblAnswer([FromBody] TblAnswer tblAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblAnswer.Add(tblAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAnswer", new { id = tblAnswer.FldAnswerId }, tblAnswer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblAnswer = await _context.TblAnswer.SingleOrDefaultAsync(m => m.FldAnswerId == id);
            if (tblAnswer == null)
            {
                return NotFound();
            }

            _context.TblAnswer.Remove(tblAnswer);
            await _context.SaveChangesAsync();

            return Ok(tblAnswer);
        }

        private bool TblAnswerExists(long id)
        {
            return _context.TblAnswer.Any(e => e.FldAnswerId == id);
        }
    }
}