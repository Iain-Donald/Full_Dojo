using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace DojoSurvey
{
    public class HomeController : Controller{
        [HttpGet]
        [Route("")]
        public ViewResult index(string error){
            return View();
        }


        [HttpGet("result")]
        public ViewResult result(Dictionary<string, string> data){ 
            ViewBag.name = data["name"];
            ViewBag.location = data["location"];
            ViewBag.favoriteLang = data["favoriteLang"];
            ViewBag.comment = data["comment"];
            ViewBag.error = data["error"];
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult process(string name, string location, string favoriteLang, string comment){
            Dictionary<string, string> data = new Dictionary<string, string>(){
            {"name", name},
            {"location", location},
            {"favoriteLang", favoriteLang},
            {"comment", comment},
            {"error", ""}
            };
            if(!isValid(name, location, favoriteLang, comment)){
                data["error"] = "Invalid input";
            } else {
                data["error"] = " ";
            }
            return RedirectToAction("result", data);
        }

        public Boolean isValid(string name, string location, string favoriteLang, string comment){
            if(name.Length < 2){
                return false;
            } else if(!(comment.Length == 0) && comment.Length < 20){
                return false;
            } else if(name.Length == 0 || location.Length == 0 || favoriteLang.Length == 0){
                return false;
            }
            return true;
        }
    }
}