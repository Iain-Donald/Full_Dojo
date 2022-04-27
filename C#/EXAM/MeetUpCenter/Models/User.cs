using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetUpCenter.Models;
namespace MeetUpCenter.Models
{
    public class User
    {
        [Key]
        public int userID {get;set;}

        [Required]
        public string name {get;set;}

        [Required]
        public string email {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string password {get;set;}

        public DateTime createdAt {get;set;} = DateTime.Now;
        public DateTime updatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public List<MeetUpJoined> meetUpJoinedTB { get; set; }
    }    
}