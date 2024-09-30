using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface ISubmitRepository
    {
        Task<Submit?> GetByIdAsync(Guid userId);
        Task<Submit> CreateAsync(Submit submitModel);
        Task<Submit?> UpdateAsync(Submit submitModel);
        Task<Submit?> DeleteAsync(Guid userId);
        Task<bool> Exists(Guid userId);
    }
}
