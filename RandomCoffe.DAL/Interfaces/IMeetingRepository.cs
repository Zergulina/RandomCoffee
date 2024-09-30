using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IMeetingRepository
    {
        Task<List<Meeting>> GetAllAsync(
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
            bool isDescending = false);
        Task<Meeting?> GetByIdAsync(Guid id);
        Task<Meeting> CreateAsync(Meeting meetingModel);
        Task<Meeting?> UpdateAsync(Meeting meetingModel);
        Task<Meeting?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
        Task<int> Count(
            Guid? organuzationId = null, 
            bool? isSuccessful = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null,
            int ? minMeetingDuration = null,
            int? maxMeetingDuration = null);
    }
}
