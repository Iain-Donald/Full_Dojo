
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dishes.Models;

using Microsoft.EntityFrameworkCore;
using Dishes.Models;
using System.Linq;
// Other using statements
namespace Dishes.Controllers
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
            //_context.SaveChanges();
            List<Dish> ALLDishes = _context.Dishes.ToList();
            ViewBag.dishList = ALLDishes;
            //ViewBag.dishList = ALLDishes.ToArray().Length;
                //.Where(u => u.chefName.ToString().Equals("Iain Donald"));
            
            return View(ALLDishes);
        }
    }
}