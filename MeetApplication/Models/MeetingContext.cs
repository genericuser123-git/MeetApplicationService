using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MeetApplication.Models
{
    public class MeetingContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<MeetingParticipants> MeetingParticipants { get; set; }
    }
}