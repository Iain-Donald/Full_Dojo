using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        [Key]
        public int dishID { get; set; }

        [Required]
        [Display(Name = "Dish Name")]
        public string dishName { get; set; }

        [Required]
        [Display(Name = "Tastiness (1-5)")]
        public int tastiness { get; set; }

        [Required]
        [Display(Name = "Calories")]
        [Range(0, 99999)]
        public int calories { get; set; }

        [Required]
        public string description { get; set; }

        public Chef chefCreator { get; set; }
        
        [Required]
        public int chefIDLink { get; set; }
    }
}