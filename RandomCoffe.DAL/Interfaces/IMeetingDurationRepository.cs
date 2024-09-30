using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IMeetingDurationRepository
    {
        Task<List<MeetingDuration>> GetAllAsync(Guid organizationId);
        Task<MeetingDuration?> GetByIdAsync(Guid id);
        Task<MeetingDuration> CreateAsync(MeetingDuration meetingDurationModel);
        Task<MeetingDuration?> UpdateAsync(MeetingDuration meetingDurationModel);
        Task<MeetingDuration?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
