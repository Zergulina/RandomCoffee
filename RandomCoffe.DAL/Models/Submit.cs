using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class Submit
    {
        [Key]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime? Date { get; set; }
        public MeetingDuration? MeetingDuration { get; set; }
        public bool IsSubmited { get; set; }
    }
}
