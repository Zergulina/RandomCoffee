using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class MeetingDuration
    {
        public Guid Id { get; set; }
        public int Duration { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<Submit> Submits { get; set; } = new List<Submit>();
    }
}
