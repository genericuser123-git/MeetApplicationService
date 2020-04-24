using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MeetApplication.Models;
using MeetApplication.Helpers;

namespace MeetApplication.Controllers
{
    public class ValuesController : ApiController
    {


        MeetingContext db = new MeetingContext();

        [HttpGet]
        public IHttpActionResult GetMeetings()
        {

            List<PackedMeeting> packedMeetings = new List<PackedMeeting>();

            foreach (Meeting meet in db.Meetings)
            {
                PackedMeeting m = new PackedMeeting();

                m.meeting = meet;
                m.participants = new List<Participant>();

                var queryMeetingParticipants = (from mp in db.MeetingParticipants
                                            join met in db.Meetings on mp.IdMeeting equals met.Id
                                            join p in db.Participants on mp.IdParticipant equals p.Id
                                            where mp.IdMeeting == meet.Id
                                            select new
                                            {
                                                PartId = p.Id,
                                                PartName = p.Name,
                                                PartEmail = p.Email
                                            }).ToList();

                

                foreach (var part in queryMeetingParticipants)
                {
                    Participant p = new Participant();
                    p.Id = part.PartId;
                    p.Name = part.PartName;
                    p.Email = part.PartEmail;
                    m.participants.Add(p);
                }

                packedMeetings.Add(m);

            }

            return Json(packedMeetings);
        
            
        }

       
        [AcceptVerbs("GET","POST")]
        public IHttpActionResult PostNewMeeting (string name, int year, int month, int day, int hour, int min)
        {

            Meeting meet = new Meeting();
            meet.Name = name;
            meet.Time = Convert.ToDateTime(String.Concat(year, "-", month, "-", day, " ", hour,":",min));
            meet.State = true;
            db.Meetings.Add(meet);
            db.SaveChanges();
            return Ok() ;
        }

        [AcceptVerbs("GET", "PUT")]
        public IHttpActionResult UpdateMeetingState (int id)
        {
            var meetingToDeactivate = db.Meetings.Where(m => m.Id == id).FirstOrDefault<Meeting>();
            if (meetingToDeactivate != null)
            {
                meetingToDeactivate.State = false;
                db.SaveChanges();
                
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [AcceptVerbs("GET", "PUT")]
        public IHttpActionResult DeleteParticipant(int id)
        {
            var participantToDelete = db.Participants.Where(p => p.Id == id).FirstOrDefault<Participant>();
            if (participantToDelete != null)
            {
                db.Entry(participantToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }

            var participantInMeetingToDelete = db.MeetingParticipants.Where(m => m.IdParticipant == id).FirstOrDefault<MeetingParticipants>();
            if (participantToDelete != null)
            {
                db.Entry(participantInMeetingToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult AddNewParticipant(string name, string mail, int meetingid)
        {

            Participant part = new Participant();
            part.Name = name;
            part.Email = mail;

            db.Participants.Add(part);
            db.SaveChanges();
            
            Participant lastpart = db.Participants.Where(p => p.Email == mail).FirstOrDefault<Participant>(); ;

            MeetingParticipants mp = new MeetingParticipants();
            mp.IdMeeting = meetingid;
            mp.IdParticipant = lastpart.Id;
            db.MeetingParticipants.Add(mp);
            db.SaveChanges();
            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /*
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        */
    }
}
