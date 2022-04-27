using System.Collections.Generic;

namespace BeltExam3HobbyHub.Models
{
    public class Dashboard
    {
        public User CurrentUser { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}