//namespace MeetUpCenter.Models
//{
    using MeetUpCenter.Models;
    public class MeetUpJoined
    {
        public int meetUpJoinedID { get; set; }

        public int meetUpID_J { get; set; }
        public MeetUp MeetUp { get; set; }
        
        public int userID_J { get; set; }
        public User User { get; set; }
    }
//}