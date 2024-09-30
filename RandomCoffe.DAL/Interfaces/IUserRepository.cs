using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IUserRepository
    {
        Task<List<User>> GetAllAsync(Guid organizationID, int pageNumber = 1, int pageSize = 20, string? name = null, string sortBy = "", bool isDescending = false);
        Task<User?> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(User userModel);
        Task<User?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
