using System;
using Microsoft.EntityFrameworkCore;
using MeetUpCenter.Models;
//namespace MeetUpCenter.Models
//{
    public class MeetUpsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MeetUpsContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MeetUp> MeetUps { get; set; }
        public DbSet<MeetUpJoined> MeetUpsJoined { get; set; }
    }
//}
