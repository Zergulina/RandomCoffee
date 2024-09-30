using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IPostRepository
    {
        Task<List<Post>> GetAllAsync(Guid organizationId);
        Task<Post?> GetByIdAsync(Guid id);
        Task<Post> CreateAsync(Post postModel);
        Task<Post?> UpdateAsync(Post postModel);
        Task<Post?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
