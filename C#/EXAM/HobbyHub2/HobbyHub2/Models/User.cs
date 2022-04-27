using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace BeltExam3HobbyHub.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        
        [Required]
        public string Username {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Will not be mapped to your users table!
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public List<HobbyJoined> HobbiesJoined { get; set; }
    }    
}