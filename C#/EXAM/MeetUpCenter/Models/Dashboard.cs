using System.Collections.Generic;
namespace MeetUpCenter.Models
{
    public class Dashboard
    {
        public User CurrentUser { get; set; }
        public List<MeetUp> MeetUps { get; set; }
    }
}