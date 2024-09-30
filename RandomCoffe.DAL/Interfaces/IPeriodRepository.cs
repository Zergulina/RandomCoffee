using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IPeriodRepository
    {
        Task<List<Period>> GetAllAsync(Guid organizationId, int pageNumber = 1, int pageSize = 20, DateTime? startDate = null, DateTime? endDate = null, string sortBy = "", bool isDescending = false);
        Task<Period?> GetByIdAsync(Guid id);
        Task<Period> CreateAsync(Period periodModel);
        Task<Period?> UpdateAsync(Period periodModel);
        Task<Period?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
