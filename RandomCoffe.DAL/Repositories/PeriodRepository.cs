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
    internal class PeriodRepository : IPeriodRepository
    {
        ApplicationDbContext _context;
        public PeriodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Period> CreateAsync(Period periodModel)
        {
            await _context.AddAsync(periodModel);
            await _context.SaveChangesAsync();
            return periodModel;
        }

        public async Task<Period?> DeleteAsync(Guid id)
        {
            var period = await _context.Periods.FirstOrDefaultAsync(x => x.Id == id);
            if (period == null)
            {
                return null;
            }

            _context.Periods.Remove(period);
            await _context.SaveChangesAsync();
            return period;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Periods.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Period>> GetAllAsync(Guid organizationId, int pageNumber = 1, int pageSize = 20, DateTime? startDate = null, DateTime? endDate = null, string sortBy = "", bool isDescending = false)
        {
            var periods = _context.Periods.Where(x => x.Id == organizationId).AsQueryable();

            if (startDate != null)
            {
                periods = periods.Where(x => x.MeetingsEnd >= startDate);
            }
            if (endDate != null)
            {
                periods = periods.Where(x => x.QueueStart <= endDate);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("StartDate", StringComparison.OrdinalIgnoreCase))
                {
                    periods = isDescending ? periods.OrderByDescending(x => x.QueueStart) : periods.OrderBy(x => x.QueueStart);
                }
                if (sortBy.Equals("PeriodLength", StringComparison.OrdinalIgnoreCase))
                {
                    periods = isDescending ? periods.OrderByDescending(x => x.MeetingsEnd - x.QueueStart) :periods.OrderBy(x => x.MeetingsEnd - x.QueueStart);
                }
            }

            return await periods.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Period?> GetByIdAsync(Guid id)
        {
            return await _context.Periods.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<Period?> UpdateAsync(Period periodModel)
        {
            var period = await _context.Periods.FirstOrDefaultAsync(x => x.Id == periodModel.Id);
            if (period == null)
            {
                return null;
            }

            _context.Periods.Update(periodModel);
            await _context.SaveChangesAsync();
            return period;
        }
    }
}
