using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey
{
    public class HomeController : Controller{
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public string HelloFromController(){
            return "Hello From Controller";
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
    }
}