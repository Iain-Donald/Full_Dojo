using System;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey
{
    public class HomeController : Controller{
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult index(){


            //Home/HiThere.cshtml
            return View();
            //return View("custom name with no extention");
            //ex. return View("HiThere");
        }

        // localhost:5000/hello
        [HttpGet("hello")]
        public string Hello(){
            return "Hi again!";
        }

        // localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location){
            if(location == "Seattle"){
                return $"Hello {username} from {location}. Go Seahawks!";
            }
            return $"Hello {username} from {location}";
            
        }

        [HttpGet("Hello2")]
        public RedirectToActionResult Hello2(){
            Console.WriteLine("Hello there, redirecting...");
            var param = new{username = "IainJ", location = "Redmond"};
            return RedirectToAction("HelloUser", param);
        }
    }
}