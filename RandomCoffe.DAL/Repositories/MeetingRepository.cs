using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Data;
using RandomCoffee.DAL.Interfaces;
using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Repositories
{
    internal class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _context;

        MeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count(
            Guid? organizationId = null, 
            bool? isSuccessful = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int? minMeetingDuration = null,
            int? maxMeetingDuration = null)
        {
            var meetings = _context.Meetings.AsQueryable();

            if (organizationId != null) 
            { 
                meetings = meetings.Where(x => x.UsersMeetings.Any(x => x.User.OrganizationId == organizationId));
            }
            if (isSuccessful != null) 
            {
                meetings = meetings.Where(x => x.IsSuccessful == isSuccessful);
            }
            if (startDate != null)
            {
                meetings = meetings.Where(x => x.Date >= startDate);
            }
            if (endDate != null)
            {
                meetings = meetings.Where(x => x.Date <= endDate);
            }
            if (minMeetingDuration != null)
            {
                meetings = meetings.Where(x => x.MeetingDuration >= minMeetingDuration);
            }
            if (maxMeetingDuration != null)
            {
                meetings = meetings.Where(x => x.MeetingDuration <= maxMeetingDuration);
            }

            return await meetings.CountAsync();
        }

        public async Task<Meeting> CreateAsync(Meeting meetingModel)
        {
            await _context.Meetings.AddAsync(meetingModel);
            await _context.SaveChangesAsync();
            return meetingModel;
        }

        public async Task<Meeting?> DeleteAsync(Guid id)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(x => x.Id == id);
            if (meeting == null)
            {
                return null;
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return meeting;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Meetings.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Meeting>> GetAllAsync(
            Guid organizationId,
            int pageNumber = 1, 
            int pageSize = 20,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int? minMeetingDuration = null,
            int? maxMeetingDuration = null,
            bool? isSuccessful = null, 
            string? FCs = null, 
            string sortBy = "", 
            bool isDescending = false)
        {
            var meetings = _context.Meetings
                .Where(x => x.UsersMeetings.Any(x => x.User.OrganizationId ==  organizationId))
                .Include(x => x.UsersMeetings)
                .ThenInclude(x => x.User)
                .Include(x => x.Photo)
                .Include(x=>x.MeetingRoom)
                .AsQueryable();

            if (startDate != null)
            {
                meetings = meetings.Where(x => x.Date >= startDate);
            }
            if (endDate != null)
            {
                meetings = meetings.Where(x => x.Date <= endDate);
            }
            if (minMeetingDuration != null)
            {
                meetings = meetings.Where(x => x.MeetingDuration >= minMeetingDuration);
            }
            if (maxMeetingDuration != null)
            {
                meetings = meetings.Where(x => x.MeetingDuration <= maxMeetingDuration);
            }
            if(isSuccessful != null)
            {
                meetings = meetings.Where(x => x.IsSuccessful == isSuccessful);
            }
            if (!string.IsNullOrWhiteSpace(FCs))
            {
                meetings = meetings.Where(x => x.UsersMeetings.Any(x => FCs.Split()
                            .All(s => x.User.Name.Contains(s, StringComparison.OrdinalIgnoreCase)  
                                || x.User.Surname.Contains(s, StringComparison.OrdinalIgnoreCase) 
                                || x.User.MiddleName.Contains(s, StringComparison.OrdinalIgnoreCase))));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                {
                    meetings = isDescending ? meetings.OrderByDescending(meeting => meeting.Date) : meetings.OrderBy(meeting => meeting.Date); 
                }
                if (sortBy.Equals("MeetingDuration", StringComparison.OrdinalIgnoreCase))
                {
                    meetings = isDescending ? meetings.OrderByDescending(meeting => meeting.MeetingDuration) : meetings.OrderBy(meeting => meeting.MeetingDuration);
                }
                if (sortBy.Equals("UserName"))
                {
                    meetings = isDescending ? meetings.OrderByDescending(meeting => meeting.UsersMeetings.Select(x => x.User.Surname + x.User.Name + x.User.MiddleName))
                        : meetings.OrderBy(meeting => meeting.UsersMeetings.Select(x => x.User.Surname + x.User.Name + x.User.MiddleName));
                }
            }

            return await meetings.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Meeting?> GetByIdAsync(Guid id)
        {
            return await _context.Meetings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Meeting?> UpdateAsync(Meeting meetingModel)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(x => x.Id == meetingModel.Id);
            if (meeting == null)
            {
                return null;
            }

            _context.Meetings.Update(meetingModel);
            await _context.SaveChangesAsync();
            return meeting;
        }
    }
}
