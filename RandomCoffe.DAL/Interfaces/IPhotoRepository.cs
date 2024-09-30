using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Interfaces
{
    internal interface IPhotoRepository
    {
        Task<Photo> CreateAsync(Photo photoModel);
        Task<Photo?> DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
