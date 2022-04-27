namespace HobbyHub.Models
{
    public class HobbyJoined
    {
        public int hobbyJoinedID { get; set; }

        public int hobbyID { get; set; }
        public Hobby Hobby { get; set; }
        
        public int userID { get; set; }
        public User User { get; set; }
    }
}