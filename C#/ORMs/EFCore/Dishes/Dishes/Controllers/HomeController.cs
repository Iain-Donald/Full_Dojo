
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

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish viewDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            return View(viewDish);
        }

        [HttpPost("posteditdish/{dishId}")]
        public IActionResult PostEditDish(Dish editedDish, int dishId)
        {
            Dish selectedDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            selectedDish.Name = editedDish.Name;
            selectedDish.chefName = editedDish.chefName;
            selectedDish.calories = editedDish.calories;
            selectedDish.tastiness = editedDish.tastiness;
            selectedDish.Description = editedDish.Description;
            selectedDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("new")]
        public IActionResult newDish()
        {
            return View();
        }

        [HttpGet("/{dishId}")]
        public IActionResult viewDish(int dishId)
        {
            Dish selectedDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(selectedDish);
        }

        [HttpPost("postnewdish")]
        public IActionResult PostNewDish(Dish newDish)
        {
            newDish.CreatedAt = DateTime.Now;
            newDish.UpdatedAt = DateTime.Now;

            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("update/{dishId}")]
        public IActionResult UpdateDish(int dishId)
        {
            Dish selectedDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            selectedDish.Name = "New name";
            selectedDish.UpdatedAt = DateTime.Now;
        
            _context.SaveChanges();
        
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish RetrievedDish = _context.Dishes.SingleOrDefault(dish => dish.DishId == dishId);

            _context.Dishes.Remove(RetrievedDish);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}