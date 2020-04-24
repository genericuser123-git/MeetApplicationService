using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetApplication.Models
{
    public class MeetingParticipants
    {
        public int Id { get; set; }
        public int IdMeeting { get; set; }
        public int IdParticipant { get; set; }
    }
}