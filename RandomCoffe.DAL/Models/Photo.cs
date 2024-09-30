using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Photo
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public Guid MeetingId { get; set; }
        public ICollection<UserPhoto> UsersPhoto { get; set; } = new List<UserPhoto>();
    }
}
