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
        [HttpGet]
        public List<Object> GetTblTeam()
        {
            var collection = _context.TblTeam;
            List<Object> collectionObj = new List<object>();

            foreach (var item in collection)
            {
                var projectfilepath = _context.TblProject.Find(item.FldProjectName).FldProjectFilePath;
                var teamNames = new
                {
                    fldTeamName = item.FldTeamName,
                    FldProjectFilePath = projectfilepath
                };
                collectionObj.Add(teamNames);
            }



            return collectionObj;
        }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetTblTeam([FromRoute] string id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamName == id);

        //        if (tblTeam == null)
        //        {
        //            return NotFound();
        //        }
        //        var tblProjectUrl = _context.TblProject.Find(tblTeam.FldProjectName).FldProjectFilePath;
        //        return Ok(tblProjectUrl);
        //    }
        //}
    }
}