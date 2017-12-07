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
    [Route("api/Topics")]
    public class TopicsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public TopicsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public IEnumerable<TblTopic> GetTblTopic()
        {
            return _context.TblTopic;
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblTopic([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTopic = await _context.TblTopic.SingleOrDefaultAsync(m => m.FldTopicId == id);

            if (tblTopic == null)
            {
                return NotFound();
            }

            return Ok(tblTopic);
        }

        // PUT: api/Topics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTopic([FromRoute] long id, [FromBody] TblTopic tblTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTopic.FldTopicId)
            {
                return BadRequest();
            }

            _context.Entry(tblTopic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTopicExists(id))
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

        // POST: api/Topics
        [HttpPost]
        public async Task<IActionResult> PostTblTopic([FromBody] TblTopic tblTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblTopic.Add(tblTopic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTopic", new { id = tblTopic.FldTopicId }, tblTopic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTopic([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTopic = await _context.TblTopic.SingleOrDefaultAsync(m => m.FldTopicId == id);
            if (tblTopic == null)
            {
                return NotFound();
            }

            _context.TblTopic.Remove(tblTopic);
            await _context.SaveChangesAsync();

            return Ok(tblTopic);
        }

        private bool TblTopicExists(long id)
        {
            return _context.TblTopic.Any(e => e.FldTopicId == id);
        }
    }
}