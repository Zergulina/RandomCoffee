using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Meeting
    {
        public Guid Id { get; set; }
        public ICollection<UserMeeting> UsersMeetings { get; set; } = new List<UserMeeting>();
        public DateTime? Date { get; set; }
        public int? MeetingDuration {  get; set; }
        public bool? IsSuccessful { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public MeetingRoom? MeetingRoom { get; set; }
    }
}
