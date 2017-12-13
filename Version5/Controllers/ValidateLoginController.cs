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
    public class ValidateLoginController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public ValidateLoginController(db_examprojecttournamentContext context)
        {
            _context = context;
        }

        // GET: api/ValidateLogin/showEncryptedPassword/adminpasswordUsername
        [Route("api/ValidateLogin/ShowEncryptedPassword/{passwordUsername}")]
        [HttpGet]
        public string GetLogins(string passwordUsername)
        {
            // Splits up the passwordUsername. So we have adminPassword and username.
            // Admin password is used for authentication to get allowed to decrypt and see the password.
            // The username is used to find the loginObject with the password that we want decrypted and shown
            // in our modal model.
            var splitted = passwordUsername.Split(",");
            var username = splitted[1];
            var adminPassword = Encryption(splitted[0], 4);
            var adminLogins = _context.TblLogin.Where(n => n.FldRank == "395");
            foreach (var item in adminLogins)
            {
                if (item.FldPassword == adminPassword)
                {
                    var loginObj = _context.TblLogin.Where(n => n.FldUsername == username);
                    var decryptedPassword = Decrypt(loginObj.Select(n => n.FldPassword), 4);
                    return decryptedPassword;
                }
            }

            return null;
        }


        [Route("api/ValidateLogin")]
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
                        return new { Status = 200, msg = "Password incorrect" };
                    }
                }

            }

            return new { Status = 200, msg = "User doesn't exist" };

        }



        private bool TblLoginExists(string id)
        {
            return _context.TblLogin.Any(e => e.FldUsername == id);
        }



        // Encryption

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

        private string Decrypt(IQueryable<string> text, int key)
        {
            List<int> asciiValuesWithKey = new List<int>();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text.First());
            foreach (var item in asciiBytes)
            {
                string value = item.ToString();
                Console.WriteLine("Value: " + value);
                int valueWithKey = (int.Parse(value) - key);
                Console.WriteLine("Value with key:" + valueWithKey);
                asciiValuesWithKey.Add(valueWithKey);
            }
            string DecryptedMessage = "";
            foreach (var item in asciiValuesWithKey)
            {
                DecryptedMessage += (Convert.ToChar(item));
            }

            return DecryptedMessage;
        }
    }






}