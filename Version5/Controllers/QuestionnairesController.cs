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
    [Route("api/Questionnaires")]
    public class QuestionnairesController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public QuestionnairesController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Questionnaires
        [HttpGet]
        public IEnumerable<TblQuestionnaire> GetTblQuestionnaire()
        {
            return _context.TblQuestionnaire;
        }

        // GET: api/Questionnaires/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblQuestionnaire([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestionnaire = await _context.TblQuestionnaire.SingleOrDefaultAsync(m => m.FldQuestionnaireId == id);

            if (tblQuestionnaire == null)
            {
                return NotFound();
            }

            return Ok(tblQuestionnaire);
        }

        // PUT: api/Questionnaires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestionnaire([FromRoute] long id, [FromBody] TblQuestionnaire tblQuestionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuestionnaire.FldQuestionnaireId)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestionnaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionnaireExists(id))
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

        // POST: api/Questionnaires
        [HttpPost]
        public async Task<IActionResult> PostTblQuestionnaire([FromBody] TblQuestionnaire tblQuestionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblQuestionnaire.Add(tblQuestionnaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuestionnaire", new { id = tblQuestionnaire.FldQuestionnaireId }, tblQuestionnaire);
        }

        // DELETE: api/Questionnaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestionnaire([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestionnaire = await _context.TblQuestionnaire.SingleOrDefaultAsync(m => m.FldQuestionnaireId == id);
            if (tblQuestionnaire == null)
            {
                return NotFound();
            }

            _context.TblQuestionnaire.Remove(tblQuestionnaire);
            await _context.SaveChangesAsync();

            return Ok(tblQuestionnaire);
        }

        private bool TblQuestionnaireExists(long id)
        {
            return _context.TblQuestionnaire.Any(e => e.FldQuestionnaireId == id);
        }
    }
}