using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(Guid id);
        Task<Department> CreateAsync(Department departmentModel);
        Task<Department?> UpdateAsync(Department departmentModel);
        Task<Department?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
