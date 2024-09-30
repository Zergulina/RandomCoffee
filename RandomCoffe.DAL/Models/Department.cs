using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
