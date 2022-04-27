using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Practice.Models;
namespace Practice.Models
{
    public class Interact
    {
        [Key]
        public int userID {get;set;}

        [Required]
        public string name {get;set;}

        [Required]
        public string intValue {get;set;}

        [Required]
        public string hashedPW {get;set;}
    }    
}