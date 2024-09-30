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
    internal class MeetingDurationRepository : IMeetingDurationRepository
    {
        private readonly ApplicationDbContext _context;
        public MeetingDurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MeetingDuration> CreateAsync(MeetingDuration meetingDurationModel)
        {
            await _context.MeetingDurations.AddAsync(meetingDurationModel);
            await _context.SaveChangesAsync();
            return meetingDurationModel;
        }

        public async Task<MeetingDuration?> DeleteAsync(Guid id)
        {
            var meetingDuration = await _context.MeetingDurations.FirstOrDefaultAsync(x => x.Id == id);
            if (meetingDuration == null) 
            {
                return null;
            }

            _context.MeetingDurations.Remove(meetingDuration);
            await _context.SaveChangesAsync();
            return meetingDuration;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.MeetingDurations.AnyAsync(x => x.Id == id);
        }

        public async Task<List<MeetingDuration>> GetAllAsync(Guid organizationId)
        {
            return await _context.MeetingDurations.Where(x => x.OrganizationId == organizationId).ToListAsync();
        }

        public async Task<MeetingDuration?> GetByIdAsync(Guid id)
        {
            return await _context.MeetingDurations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MeetingDuration?> UpdateAsync(MeetingDuration meetingDurationModel)
        {
            var meetingDuration = await _context.MeetingDurations.FirstOrDefaultAsync(x => x.Id == meetingDurationModel.Id);
            if (meetingDuration == null)
            {
                return null;
            }

            _context.MeetingDurations.Update(meetingDurationModel);
            await _context.SaveChangesAsync();
            return meetingDuration;
        }
    }
}
