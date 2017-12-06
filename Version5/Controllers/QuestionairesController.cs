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
    [Route("api/Questionaires")]
    public class QuestionairesController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public QuestionairesController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Questionaires
        [HttpGet]
        public IEnumerable<TblQuestionaire> GetTblQuestionaire()
        {
            return _context.TblQuestionaire;
        }

        // GET: api/Questionaires/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblQuestionaire([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestionaire = await _context.TblQuestionaire.SingleOrDefaultAsync(m => m.FldQuestionaireId == id);

            if (tblQuestionaire == null)
            {
                return NotFound();
            }

            return Ok(tblQuestionaire);
        }

        // PUT: api/Questionaires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestionaire([FromRoute] long id, [FromBody] TblQuestionaire tblQuestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuestionaire.FldQuestionaireId)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestionaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionaireExists(id))
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

        // POST: api/Questionaires
        [HttpPost]
        public async Task<IActionResult> PostTblQuestionaire([FromBody] TblQuestionaire tblQuestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblQuestionaire.Add(tblQuestionaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuestionaire", new { id = tblQuestionaire.FldQuestionaireId }, tblQuestionaire);
        }

        // DELETE: api/Questionaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestionaire([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestionaire = await _context.TblQuestionaire.SingleOrDefaultAsync(m => m.FldQuestionaireId == id);
            if (tblQuestionaire == null)
            {
                return NotFound();
            }

            _context.TblQuestionaire.Remove(tblQuestionaire);
            await _context.SaveChangesAsync();

            return Ok(tblQuestionaire);
        }

        private bool TblQuestionaireExists(long id)
        {
            return _context.TblQuestionaire.Any(e => e.FldQuestionaireId == id);
        }
    }
}