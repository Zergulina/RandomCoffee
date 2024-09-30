using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface ICoffeeRepository
    {
        Task<List<Coffee>> GetAllAsync();
        Task<Coffee?> GetByIdAsync(Guid id);
        Task<Coffee> CreateAsync(Coffee coffeeModel);
        Task<Coffee?> UpdateAsync(Coffee coffeeModel);
        Task<Coffee?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);

    }
}
