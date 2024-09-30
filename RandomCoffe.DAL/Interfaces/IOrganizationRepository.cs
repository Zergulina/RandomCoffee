using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IOrganizationRepository
    {
        Task<List<Organization>> GetAllAsync(int pageNumber = 1, int pageSize = 20, string? name = null, string sortBy = "", bool isDescending = false);
        Task<Organization?> GetByIdAsync(Guid id);
        Task<Organization> CreateAsync(Organization organizationModel);
        Task<Organization?> UpdateAsync(Organization organizationModel);
        Task<Organization?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
