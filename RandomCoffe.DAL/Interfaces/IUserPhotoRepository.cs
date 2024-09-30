using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IUserPhotoRepository
    {
        Task<UserPhoto> CreateAsync(UserPhoto userMeetingModel);
        Task<UserPhoto?> DeleteAsync(Guid userId, Guid photoId);
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
