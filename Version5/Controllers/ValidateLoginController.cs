using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Version5.Models;
using System.Text;
using System;

namespace Version5.Controllers
{
    [Produces("application/json")]
    [Route("api/ValidateLogin")]
    public class ValidateLoginController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public ValidateLoginController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public object PostTblLogin([FromBody] TblLogin tblLogin)
        {

            if (!ModelState.IsValid)
            {
                return new { Status = 300, msg = "Error in db" };
            }

            tblLogin.FldPassword = Encryption(tblLogin.FldPassword, 4);

            foreach (var login in _context.TblLogin)
            {
                if (login.FldUsername == tblLogin.FldUsername)
                {

                    if (login.FldPassword == tblLogin.FldPassword)
                    {
                        return new { Status = 100, Rank = login.FldRank };
                    }
                    else
                    {
                        return new { Status = 200, msg = "Password isn't correct" };
                    }
                }

            }

            return new { Status = 200, msg = "User doesn't exist" };

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