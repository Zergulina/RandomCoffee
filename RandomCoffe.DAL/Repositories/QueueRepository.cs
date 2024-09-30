using Microsoft.EntityFrameworkCore;
using RandomCoffee.DAL.Data;
using RandomCoffee.DAL.Interfaces;
using RandomCoffee.DAL.Models;

namespace RandomCoffee.DAL.Repositories
{
    internal class QueueRepository : IQueueRepository
    {
        ApplicationDbContext _context;
        public QueueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count(Guid? organizationId)
        {
            if (organizationId == null)
            {
                return await _context.Queues.CountAsync();
            }

            return await _context.Queues.Where(x => x.User.OrganizationId == organizationId).CountAsync();
        }

        public async Task<Queue> CreateAsync(Queue queueModeel)
        {
            await _context.AddAsync(queueModeel);
            await _context.SaveChangesAsync();
            return queueModeel;
        }

        public async Task<Queue?> DeleteAsync(Guid userId)
        {
            var queue = await _context.Queues.FirstOrDefaultAsync(x => x.UserId == userId);
            if (queue == null)
            {
                return null;
            }
            _context.Queues.Remove(queue);
            await _context.SaveChangesAsync();
            return queue;
        }

        public async Task<bool> Exists(Guid userId)
        {
            return await _context.Queues.AnyAsync(x => x.UserId == userId);
        }

        public Task<List<Queue>> GetAllAsync(Guid organizationId, string? fcs = null, string sortBy = "", bool isDescending = false)
        {
            var queues = _context.Queues.Where(x => x.User.OrganizationId == organizationId).AsQueryable();

            if (fcs != null)
            {
                queues = queues.Where(x => fcs.Split()
                            .All(s => x.User.Name.Contains(s, StringComparison.OrdinalIgnoreCase)
                                || x.User.Surname.Contains(s, StringComparison.OrdinalIgnoreCase)
                                || x.User.MiddleName.Contains(s, StringComparison.OrdinalIgnoreCase)));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("Fcs"))
                {
                    queues = isDescending ? queues.OrderByDescending(x => x.User.Surname + x.User.Name + x.User.MiddleName) :
                        queues.OrderBy(x => x.User.Surname + x.User.Name + x.User.MiddleName);
                }
            }

            return queues.ToListAsync();
        }


    }
}
