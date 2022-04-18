using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Hockey"))
                .ToList();

            ViewBag.NotFootball = _context.Leagues
                .Where(l => !l.Name.Contains("Football"))
                .ToList();

            ViewBag.isConference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.isAtlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.inDallas = _context.Teams
                .Where(t => t.Location.Contains("Dallas"))
                .ToList();

            ViewBag.Raptors = _context.Teams
                .Where(t => t.TeamName.Contains("Raptor"))
                .ToList();

            ViewBag.CityName = _context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();

            ViewBag.TNames = _context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.OrderedLocation = _context.Teams
                .OrderBy(t => t.Location)
                .ToList();
            
            /*List<SportsORM.Models.Team> OrderedTeamReverse = _context.Teams
                .OrderBy(t => t.TeamName)
                .ToList();
            OrderedTeamReverse = OrderedTeamReverse.Reverse();
            ViewBag.OrderedTeamReverse = OrderedTeamReverse;*/

            ViewBag.OrderedTeamReverse = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();

            ViewBag.Cooper = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();

            ViewBag.Joshua = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();

            ViewBag.CooperExcJoshua = _context.Players
                .Where(p => p.LastName.Contains("Cooper") && !p.FirstName.Contains("Joshua"))
                .ToList();

            ViewBag.AlexanderOrWyatt = _context.Players
                .Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"))
                .ToList();
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}