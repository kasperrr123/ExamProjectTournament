using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version5.Models;
using Microsoft.EntityFrameworkCore;

namespace Version5.Controllers
{
    [Produces("application/json")]
    [Route("api/GetProjectURL")]
    public class GetProjectURLController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public GetProjectURLController(db_examprojecttournamentContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblTeam([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamName == id);

            if (tblTeam == null)
            {
                return NotFound();
            }
            var tblProjectUrl = _context.TblProject.Find(tblTeam.FldProjectName).FldProjectFilePath;
            return Ok(tblProjectUrl);
        }
    }
}