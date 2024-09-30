using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public string SecretKey {  get; set; }
        public string AdminLogin { get; set; }
        public string AdminPassword { get; set; }
        public bool AutoPeriods {  get; set; } = true;
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public ICollection<Period> Periods { get; set; } = new List<Period>();
        public ICollection<MeetingDuration> MeetingDurations { get; set; } = new List<MeetingDuration>();
    }
}
