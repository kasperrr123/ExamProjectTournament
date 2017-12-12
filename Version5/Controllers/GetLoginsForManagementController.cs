using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version5.Models;

namespace Version5.Controllers
{
    [Produces("application/json")]
    public class GetLoginsForManagementController : Controller
    {


        private readonly db_examprojecttournamentContext _context;

        public GetLoginsForManagementController(db_examprojecttournamentContext context)
        {
            _context = context;
        }


        // GET: api/GetLoginsForManagement/Teams
        [Route("api/Logins/management/{rank}")]
        [HttpGet]
        public List<TblTeam> GetTeams(string rank)
        {
            var email = _context.TblLogin.Where(n => n.FldRank == rank).Select(n=>n.FldUsername);
            List<TblTeam> toReturn = new List<TblTeam>();
            foreach (var item in email)
            {
                toReturn.Add(_context.TblTeam.Where(n => n.FldUsername == item).First());

            }
            return toReturn;

        }
     


        // PUT: api/GetLoginsForManagement/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
