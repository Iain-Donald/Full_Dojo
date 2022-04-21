using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;
using System.Linq;
// Other using statements
namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }
     
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = _context.CRUDelicious.ToList();
            
            return View();
        }
    }
}
