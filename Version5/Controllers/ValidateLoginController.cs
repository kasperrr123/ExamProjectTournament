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
    [Route("api/ValidateLogin")]
    public class ValidateLoginController : Controller
    {
        private readonly db_examprojecttournamentContext _context;



        [HttpPost]
        public async Task<IActionResult> PostTblLogin([FromBody] TblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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




        private bool TblLoginExists(string id)
        {
            return _context.TblLogin.Any(e => e.FldUsername == id);
        }

    }

  

   


}