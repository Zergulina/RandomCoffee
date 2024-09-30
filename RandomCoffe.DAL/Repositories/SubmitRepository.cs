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
    internal class SubmitRepository : ISubmitRepository
    {
        ApplicationDbContext _context;
        public SubmitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Submit> CreateAsync(Submit submitModel)
        {
            await _context.Submits.AddAsync(submitModel);
            await _context.SaveChangesAsync();
            return submitModel;
        }

        public async Task<Submit?> DeleteAsync(Guid userId)
        {
            var submit = await _context.Submits.FirstOrDefaultAsync(x => x.UserId == userId);
            if (submit == null) 
            { 
                return null;
            }

            _context.Submits.Remove(submit);
            await _context.SaveChangesAsync();
            return submit;
        }

        public async Task<bool> Exists(Guid userId)
        {
            return await _context.Submits.AnyAsync(x => x.UserId == userId);
        }

        public async Task<Submit?> GetByIdAsync(Guid userId)
        {
            return await _context.Submits.FirstOrDefaultAsync(x =>x.UserId == userId);
        }

        public async Task<Submit?> UpdateAsync(Submit submitModel)
        {
            var submit = await _context.Submits.FirstOrDefaultAsync(x => x.UserId == submitModel.UserId);

            if (submit == null)
            {
                return null;
            }

            _context.Submits.Update(submit);
            await _context.SaveChangesAsync();
            return submit;
        }
    }
}
