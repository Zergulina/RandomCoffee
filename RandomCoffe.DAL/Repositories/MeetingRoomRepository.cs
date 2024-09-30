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
    internal class MeetingRoomRepository : IMeetingRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public MeetingRoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MeetingRoom> CreateAsync(MeetingRoom meetingRoomModel)
        {
            await _context.MeetingRooms.AddAsync(meetingRoomModel);
            await _context.SaveChangesAsync();
            return meetingRoomModel;
        }

        public async Task<MeetingRoom?> DeleteAsync(Guid id)
        {
            var meetingRoom = await _context.MeetingRooms.FirstOrDefaultAsync(x => x.MeetingId == id);
            if (meetingRoom == null)
            {
                return null;
            }

            _context.MeetingRooms.Remove(meetingRoom);
            await _context.SaveChangesAsync();
            return meetingRoom;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.MeetingRooms.AnyAsync(x => x.MeetingId == id);
        }

        public async Task<MeetingRoom?> GetByIdAsync(Guid id)
        {
            return await _context.MeetingRooms.FirstOrDefaultAsync(x => x.MeetingId == id);
        }
    }
}
