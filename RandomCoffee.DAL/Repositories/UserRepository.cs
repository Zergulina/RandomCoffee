using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Data;
using RandomCoffee.DAL.Interfaces;
using RandomCoffee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace RandomCoffee.DAL.Repositories
//{
//    internal class UserRepository : IRepository<User>
//    {
//        private readonly ApplicationDbContext _context;
//        UserRepository(ApplicationDbContext context) 
//        { 
//            _context = context;
//        }
//        public async Task<User> CreateAsync(User model)
//        {
//            await _context.Users.AddAsync(model);
//            await _context.SaveChangesAsync();
//            return model;
//        }

//        public async Task<User?> DeleteAsync(Guid id)
//        {
//            var model = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
//            if (model == null) return null;
//            _context.Users.Remove(model);
//            await _context.SaveChangesAsync();
//            return model;
//        }

//        public async Task<bool> Exists(Guid id)
//        {
//            return await _context.Users.AnyAsync(x => x.Id == id);
//        }

//        public async Task<List<User>> GetAll()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        public async Task<User?> GetByIdAsync(Guid id)
//        {
//            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<bool> UpdateAsync(User model)
//        {
//            if (!await Exists(model.Id)) return false;
//            _context.Entry(model).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
