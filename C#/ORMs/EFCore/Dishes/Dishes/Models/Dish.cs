using System;
using System.ComponentModel.DataAnnotations;
//namespace Dishes.Models
//{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; }
        public string chefName { get; set; }
        public string Description { get; set; }
        public int calories { get; set; }
        public int tastiness { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
//}