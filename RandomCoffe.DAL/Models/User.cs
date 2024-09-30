using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public byte[]? Image { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Department? Department { get; set; }
        public Post? Post { get; set; }
        public string Pets { get; set; } = string.Empty;
        public string Hobbies = string.Empty;
        public Guid? CoffeeId { get; set; }
        public Coffee? Coffee { get; set; }
        public string Telegram { get; set; } = string.Empty;
        public string Vk { get; set; } = string.Empty;
        public Queue Queue { get; set; }
        public ICollection<UserMeeting> UsersMeetings { get; set; } = new List<UserMeeting>();
        public Submit? Submit { get; set; }
        public ICollection<UserPhoto> UsersPhoto { get; set; } = new List<UserPhoto>();
    }
}
