using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MeetApplication.Models
{
    public class MeetingDbInitializer: DropCreateDatabaseAlways<MeetingContext>
    {
        protected override void Seed(MeetingContext db)
        {
            db.Meetings.Add(new Meeting { Name = "Совещание", Time = Convert.ToDateTime("2020-04-23 17:00"), State = true });
            db.Participants.Add(new Participant { Name = "Николай", Email = "nik@mail.ru"});
            db.Participants.Add(new Participant { Name = "Алёна", Email = "ale@mail.ru" });
            db.MeetingParticipants.Add(new MeetingParticipants { IdMeeting = 1, IdParticipant = 1 }) ;

            base.Seed(db);
        }
    }
}