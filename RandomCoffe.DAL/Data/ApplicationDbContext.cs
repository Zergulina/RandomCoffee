using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingDuration> MeetingDurations { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }    
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Submit> Submits { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPhoto> UsersPhoto { get; set; }
        public DbSet<UserMeeting> UsersMeetings { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPhoto>(up => up.HasKey(up => new { up.UserId, up.PhotoId}));
            modelBuilder.Entity<UserPhoto>().HasOne(up => up.User).WithMany(u => u.UsersPhoto).HasForeignKey(up=> up.UserId);
            modelBuilder.Entity<UserPhoto>().HasOne(up => up.Photo).WithMany(p => p.UsersPhoto).HasForeignKey(up => up.PhotoId);
            
            modelBuilder.Entity<UserMeeting>(um => um.HasKey(um => new {um.UserId, um.MeetingId}));
            modelBuilder.Entity<UserMeeting>().HasOne(um => um.User).WithMany(u => u.UsersMeetings).HasForeignKey(um => um.UserId);
            modelBuilder.Entity<UserMeeting>().HasOne(um => um.Meeting).WithMany(m => m.UsersMeetings).HasForeignKey(um => um.MeetingId);
        }
    }
}
