using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetApplication.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public bool State { get; set; }
    }
}