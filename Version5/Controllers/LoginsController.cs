using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Version5.Models;
using System.Text;

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
        public async Task<IActionResult> GetTblLogin([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLogin = await _context.TblLogin.SingleOrDefaultAsync(m => m.FldUsername == id);

            if (tblLogin == null)
            {
                return NotFound();
            }

            return Ok(tblLogin);
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogin([FromRoute] string id, [FromBody] TblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLogin.FldUsername)
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


            tblLogin.FldPassword = Encryption(tblLogin.FldPassword, 4);

            _context.TblLogin.Add(tblLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblLoginExists(tblLogin.FldUsername))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblLogin", new { id = tblLogin.FldUsername }, tblLogin);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogin([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblLogin = await _context.TblLogin.SingleOrDefaultAsync(m => m.FldUsername == id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            _context.TblLogin.Remove(tblLogin);
            await _context.SaveChangesAsync();

            return Ok(tblLogin);
        }

        private bool TblLoginExists(string id)
        {
            return _context.TblLogin.Any(e => e.FldUsername == id);
        }


        private string Encryption(string text, int key)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            List<int> asciiValuesWithKey = new List<int>();
            foreach (var item in asciiBytes)
            {
                string value = item.ToString();
                int valueWithKey = int.Parse(value) + key;
                asciiValuesWithKey.Add(valueWithKey);
            }

            string encryptedMessage = "";
            foreach (var item in asciiValuesWithKey)
            {
                encryptedMessage += (Convert.ToChar(item));
            }

            return encryptedMessage;
        }

    }
}