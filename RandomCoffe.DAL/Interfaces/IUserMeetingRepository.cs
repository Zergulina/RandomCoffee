using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IUserMeetingRepository
    {
        Task<UserMeeting> CreateAsync(UserMeeting userMeetingModel);
        Task<UserMeeting?> DeleteAsync(Guid meetingId, Guid userId);
        Task<UserMeeting?> GetByUserIdAsync(
            Guid userId,
            int pageNumber = 1,
            int pageSize = 20,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int? minMeetingDuration = null,
            int? maxMeetingDuration = null,
            bool? isSuccessful = null,
            string sortBy = "",
            bool isDescending = false
            );
    }
}
