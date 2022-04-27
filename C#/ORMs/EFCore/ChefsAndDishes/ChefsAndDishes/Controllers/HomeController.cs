using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller {
        private MyContext _context;
        public HomeController(MyContext context){
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Chefs(){
            List<Chef> AllChefs = new List<Chef> { };
            if (_context.Chefs.ToList().Count > 0){
                AllChefs = _context.Chefs
                .Include(chef => chef.Dishes)
                .ToList();
            }
            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef(){
            return View();
        }

        [HttpPost("post_chef")]
        public IActionResult PostNewChef(Chef chef){
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return RedirectToAction("Chefs");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes(){
            List<Dish> AllDishes = new List<Dish> { };

            if (_context.Dishes.ToList().Count > 0){
                AllDishes = _context.Dishes
                    .Include(dish => dish.chefCreator)
                    .ToList();
            }
            return View(AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish(){
            List<Chef> AllChefs = _context.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        [HttpPost("post_dish")]
        public IActionResult PostNewDish(Dish dish){
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
    }
}
