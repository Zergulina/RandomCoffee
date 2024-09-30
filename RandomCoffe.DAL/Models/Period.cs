using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Period
    {
        public Guid Id { get; set; }
        public DateTime QueueStart { get; set; }
        public DateTime QueueEnd { get; set; }
        public DateTime MeetingsEnd { get; set; }
        public Guid OrganizationID { get; set; }
    }
}
