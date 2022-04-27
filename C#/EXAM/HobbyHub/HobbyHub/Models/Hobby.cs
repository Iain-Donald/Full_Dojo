using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models
{
    public class Hobby
    {
        public int hobbyID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public List<HobbyJoined> UsersJoined { get; set; }
    }
}