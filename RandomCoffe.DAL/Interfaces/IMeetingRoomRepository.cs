using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IMeetingRoomRepository
    {
        Task<MeetingRoom?> GetByIdAsync(Guid id);
        Task<MeetingRoom> CreateAsync(MeetingRoom meetingRoomModel);
        Task<MeetingRoom?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
