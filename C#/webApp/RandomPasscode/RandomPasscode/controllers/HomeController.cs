using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace RandomPasscode
{
    public class HomeController : Controller{
        [HttpGet]
        [Route("")]
        public ViewResult index(string error){
            return View();
        }
    }
}