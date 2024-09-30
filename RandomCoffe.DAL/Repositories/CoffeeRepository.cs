using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Data;
using RandomCoffee.DAL.Interfaces;
using RandomCoffee.DAL.Models;

namespace RandomCoffee.DAL.Repositories
{
    internal class CoffeeRepository : ICoffeeRepository
    {
        private readonly ApplicationDbContext _context;
        public CoffeeRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<Coffee> CreateAsync(Coffee coffeeModel)
        {
            await _context.Coffee.AddAsync(coffeeModel);
            await _context.SaveChangesAsync();
            return coffeeModel;
        }

        public async Task<Coffee?> DeleteAsync(Guid id)
        {
            var coffee = await _context.Coffee.FirstOrDefaultAsync(x => x.Id == id);
            if (coffee == null)
            {
                return null;
            }

            _context.Remove(coffee);
            await _context.SaveChangesAsync();
            return coffee;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Coffee.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Coffee>> GetAllAsync()
        {
            return await _context.Coffee.ToListAsync();
        }

        public async Task<Coffee?> GetByIdAsync(Guid id)
        {
            return await _context.Coffee.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Coffee?> UpdateAsync(Coffee coffeeModel)
        {
            var coffee = await _context.Coffee.FirstOrDefaultAsync(x => x.Id == coffeeModel.Id);
            if (coffee == null)
            {
                return null;
            }

            _context.Update(coffeeModel);
            await _context.SaveChangesAsync();
            return coffee;
        }
    }
}
