using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface ITopicRepository
    {
        Task<List<Topic>> GetAllAsync(Guid organizationID, int pageNumber = 1, int pageSize = 20, string? name = null, string sortBy = "", bool isDescending = false);
        Task<Topic?> GetByIdAsync(Guid id);
        Task<Topic> CreateAsync(Topic topicModel);
        Task<Topic?> UpdateAsync(Topic topicModel);
        Task<Topic?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
