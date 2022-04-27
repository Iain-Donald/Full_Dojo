using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MeetUpCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MeetUpCenter.Controllers
{
    public class HomeController : Controller {
        private MeetUpsContext _context;
        public HomeController(MeetUpsContext context){
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index(){
            HttpContext.Session.SetString("error", "");
            return RedirectToAction("MeetUps");
        }

        [HttpGet("login")]
        public IActionResult LoginReg(){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID != null) return RedirectToAction("MeetUps");

            return View();
        }

        [HttpPost("register")]
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

        [HttpPost("confirmlogin")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid){
                var userInDb = _context.Users.FirstOrDefault(u => u.email == userSubmission.loginEmail);
                if (userInDb is null){
                    ModelState.AddModelError("loginEmail", "Invalid Email/Password");
                    Console.WriteLine("////////////////////////////Invalid Email/Password");
                    HttpContext.Session.SetString("error", "Error: Invalid Email/Password");
                    ViewBag.error = HttpContext.Session.GetString("error");
                    return View("LoginReg");
                }

                // Initialize hasher
                var hasher = new PasswordHasher<LoginUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.password, userSubmission.loginPassword);
                
                HttpContext.Session.SetInt32("logged_in_id", userInDb.userID);
                HttpContext.Session.SetString("error", "");
                return RedirectToAction("MeetUps");
                
            }
            return View("LoginReg");
        }

        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("MeetUps");
        }

        [HttpGet("home")]
        public IActionResult MeetUps(){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID is null) return RedirectToAction("LoginReg");

            var MeetUps = _context.MeetUps.ToList();
            Dashboard dash = new Dashboard();
            dash.MeetUps = _context.MeetUps
                .Include(a => a.UsersJoined)
                    .ThenInclude(b => b.User)
                .ToList();
            dash.CurrentUser = _context.Users.FirstOrDefault(u => u.userID == (int)userID);
            ViewBag.Users = _context.MeetUpsJoined;
            return View(dash);
        }

        [HttpGet("new")]
        public IActionResult NewMeetUp(){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID is null) return RedirectToAction("LoginReg");

            return View();
        }

        [HttpPost("post_new_meetup")]
        public IActionResult PostNewMeetUp(MeetUp meetup){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID is null) return RedirectToAction("LoginReg");

            if (ModelState.IsValid){
                if(DateTime.Compare(DateTime.Parse(meetup.dateAndTime), DateTime.Now) < 1){
                    return RedirectToAction("MeetUps");
                }
                _context.MeetUps.Add(meetup);
                Console.WriteLine("///////////////NAME: " + meetup.name);
                Console.WriteLine("///////////////DATETIME: " + meetup.dateAndTime);
                Console.WriteLine("///////////////DURATION: " + meetup.duration);
                Console.WriteLine("///////////////DESCRIPTION: " + meetup.description);
                MeetUpJoined newUserJoined = new MeetUpJoined();
                newUserJoined.meetUpID_J = meetup.MeetUpID;
                newUserJoined.userID_J = (int)userID;
                _context.MeetUpsJoined.Add(newUserJoined);
                _context.SaveChanges();
                return RedirectToAction("MeetUps");
            }
            return View("NewMeetUp");
        }

        [HttpGet("meetup/{meetupID}")]
        public IActionResult ViewMeetUp(int meetupID){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID is null) return RedirectToAction("LoginReg");

            ViewBag.name = _context.Users.FirstOrDefault(u => u.userID == userID).name;
            ViewBag.loggedInId = HttpContext.Session.GetInt32("logged_in_id");

            string[] Participants = new string[10];
            /*foreach (var User in _context.MeetUpsJoined.){
                Participants.Append(User.name);
            }*/
            ViewBag.ViewParticipants = Participants;

            MeetUp meetup = _context.MeetUps
                .Include(x => x.UsersJoined)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(m => m.MeetUpID == meetupID);

            return View(meetup);
        }

        [HttpGet("meetup/{meetupID}/join")]
        public IActionResult JoinMeetUp(int meetupID){
            //check logged in
            int? userID = HttpContext.Session.GetInt32("logged_in_id");
            if (userID is null) return RedirectToAction("LoginReg");

            MeetUpJoined newJoin = new MeetUpJoined();
            newJoin.userID_J = (int)userID;
            newJoin.meetUpID_J = meetupID;
            _context.MeetUpsJoined.Add(newJoin);
            _context.SaveChanges();

            return RedirectToAction("MeetUps");
        }
    }
}
