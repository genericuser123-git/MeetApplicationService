using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetApplication.Models;

namespace MeetApplication.Helpers
{
    public class PackedMeeting
    {
        public Meeting meeting;
        public List<Participant> participants;

        public PackedMeeting ( )
        {
           // meeting = meet;
            //participants = parts;
        }
    }
}