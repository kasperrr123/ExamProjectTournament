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
    [Route("api/GetFldTeamName")]
    public class GetFldTeamNameController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public GetFldTeamNameController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public List<Object> GetTblTeam()
        {
            var collection = _context.TblTeam.Select(m => m.FldTeamName);
            List<Object> collectionObj = new List<object>();

            foreach (var item in collection)
            {
                var teamNames = new
                {
                    fldTeamName = item
                };
                collectionObj.Add(teamNames);
            }
           


            return collectionObj;
        }



    }
}