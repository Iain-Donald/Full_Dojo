using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//namespace MeetUpCenter.Models
//{
    public class MeetUp
    {
        public int MeetUpID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string dateAndTime { get; set; }

        
        public string duration { get; set; }

        [Required]
        public string description { get; set; }

        public List<MeetUpJoined> UsersJoined { get; set; }
    }
//}