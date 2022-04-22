using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
namespace RandomPasscode
{
    public class HomeController : Controller{
        [HttpGet]
        [Route("index")]
        public ViewResult index(){
            /*Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");*/
            
            /*byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[14]);
            char[] pw = new char[14];
            for(int i = 0; i < pw.Length; i++){
                pw[i] = Convert.ToChar(salt[i]);
                Console.WriteLine(i + ": " + pw[i]);
            }*/
            if(HttpContext.Session.GetInt32("count") == null){
                HttpContext.Session.SetInt32("count", 1);
            }
            ViewBag.count = HttpContext.Session.GetInt32("count");
            HttpContext.Session.SetString("passcode", generatePW());
            ViewBag.passcode = HttpContext.Session.GetString("passcode");
            return View();
        }
        
        [HttpGet("generate")]
        public RedirectToActionResult generate(){
            HttpContext.Session.SetString("passcode", generatePW());
            HttpContext.Session.SetInt32("count", HttpContext.Session.GetInt32("count").Value + 1);
            return RedirectToAction("index");
        }

        public string generatePW(){
            string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder pw = new StringBuilder();
            Random r = new Random();

            for(int i = 0; i < 14; i++){
                pw.Append(valid[r.Next(valid.Length)]);
            }

            
            return pw.ToString();
        }
    }
}