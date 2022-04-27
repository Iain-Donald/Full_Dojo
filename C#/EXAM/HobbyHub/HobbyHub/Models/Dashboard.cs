using System.Collections.Generic;
using HobbyHub.Models;
namespace HobbyHub.Models
{
    public class Dashboard
    {
        public User CurrentUser { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}