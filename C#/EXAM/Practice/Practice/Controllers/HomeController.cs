using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practice.Models;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult register(User user){
            //if (ModelState.IsValid){
                // If a User exists with provided Username
                if (_context.Users.Any(u => u.email == user.email)){
                    // Manually add a ModelState error to the Username field, with provided
                    // error message
                    ModelState.AddModelError("email", "Email already in use!");
                    Console.WriteLine("///////////////EMAIL IN USE");
                    HttpContext.Session.SetString("error", "Email already in use");
                    ViewBag.error = HttpContext.Session.GetString("error");

                    return View("LoginReg");
                }
                Console.WriteLine("///////////////NAME: " + user.name);
                Console.WriteLine("///////////////EMAIL: " + user.email);
                Console.WriteLine("///////////////PASSWORD: " + user.password);
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                
                user.password = hasher.HashPassword(user, user.password);
                _context.Users.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("logged_in_id", user.userID);
                return RedirectToAction("MeetUps");
            //}
            return View("LoginReg");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
