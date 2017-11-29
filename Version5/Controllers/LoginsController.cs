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
    [Route("api/Logins")]
    public class LoginsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public LoginsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public IEnumerable<TblLogin> GetTblLogin()
        {
            return _context.TblLogin;
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblLogin([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLogin = await _context.TblLogin.SingleOrDefaultAsync(m => m.FldLoginId == id);

            if (tblLogin == null)
            {
                return NotFound();
            }

            return Ok(tblLogin);
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogin([FromRoute] long id, [FromBody] TblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLogin.FldLoginId)
            {
                return BadRequest();
            }

            _context.Entry(tblLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLoginExists(id))
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

        // POST: api/Logins
        [HttpPost]
        public async Task<IActionResult> PostTblLogin([FromBody] TblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblLogin.Add(tblLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLogin", new { id = tblLogin.FldLoginId }, tblLogin);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogin([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLogin = await _context.TblLogin.SingleOrDefaultAsync(m => m.FldLoginId == id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            _context.TblLogin.Remove(tblLogin);
            await _context.SaveChangesAsync();

            return Ok(tblLogin);
        }

        private bool TblLoginExists(long id)
        {
            return _context.TblLogin.Any(e => e.FldLoginId == id);
        }
    }
}