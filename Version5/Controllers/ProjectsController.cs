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
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public ProjectsController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<TblProject> GetTblProject()
        {
            return _context.TblProject;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblProject([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblProject = await _context.TblProject.SingleOrDefaultAsync(m => m.FldProjectName == id);

            if (tblProject == null)
            {
                return NotFound();
            }

            return Ok(tblProject);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProject([FromRoute] string id, [FromBody] TblProject tblProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProject.FldProjectName)
            {
                return BadRequest();
            }

            _context.Entry(tblProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> PostTblProject([FromBody] TblProject tblProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblProject.Add(tblProject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProjectExists(tblProject.FldProjectName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProject", new { id = tblProject.FldProjectName }, tblProject);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProject([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblProject = await _context.TblProject.SingleOrDefaultAsync(m => m.FldProjectName == id);
            if (tblProject == null)
            {
                return NotFound();
            }

            _context.TblProject.Remove(tblProject);
            await _context.SaveChangesAsync();

            return Ok(tblProject);
        }

        private bool TblProjectExists(string id)
        {
            return _context.TblProject.Any(e => e.FldProjectName == id);
        }
    }
}