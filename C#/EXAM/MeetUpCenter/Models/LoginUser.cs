using System;
using System.ComponentModel.DataAnnotations;
namespace MeetUpCenter.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name="email")]
        public string loginEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="password")]
        public string loginPassword { get; set; }
    }

}