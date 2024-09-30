using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IQueueRepository
    {
        Task<List<Queue>> GetAllAsync(Guid organizationId, string? fcs = null, string sortBy = "", bool isDescending = false);
        Task<Queue> CreateAsync(Queue queueModeel);
        Task<Queue?> DeleteAsync(Guid userId);
        Task<bool> Exists(Guid userId);
        Task<int> Count(Guid? organizationId);
    }
}
