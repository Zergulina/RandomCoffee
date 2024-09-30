using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Models
{
    internal class UserPhoto
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid PhotoId { get; set; }
        public Photo Photo{ get; set; } = null!;
    }
}
