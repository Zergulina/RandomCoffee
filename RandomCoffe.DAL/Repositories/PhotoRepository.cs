using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Data;
using RandomCoffee.DAL.Interfaces;
using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCoffee.DAL.Repositories
{
    internal class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _context;
        public PhotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Photo> CreateAsync(Photo photoModel)
        {
            await _context.Photo.AddAsync(photoModel);
            await _context.SaveChangesAsync();
            return photoModel;
        }

        public async Task<Photo?> DeleteAsync(Guid id)
        {
            var photo = await _context.Photo.FirstOrDefaultAsync(x => x.Id == id);
            if (photo == null) 
            { 
                return null;
            }

            _context.Photo.Remove(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Photo.AnyAsync(x => x.Id == id);
        }
    }
}
