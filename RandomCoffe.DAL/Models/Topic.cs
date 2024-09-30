using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Topic
    {
        public Guid Id { get; set; }
        public string Description {  get; set; }
        public Guid OrganizationId { get; set; }
    }
}
