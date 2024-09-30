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
    internal class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Organization> CreateAsync(Organization organizationModel)
        {
            await _context.Organizations.AddAsync(organizationModel);
            await _context.SaveChangesAsync();
            return organizationModel;
        }

        public async Task<Organization?> DeleteAsync(Guid id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (organization == null)
            {
                return null;
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
            return organization;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Organizations.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Organization>> GetAllAsync(int pageNumber = 1, int pageSize = 20, string? name = null, string sortBy = "", bool isDescending = false)
        {
            var organizations = _context.Organizations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                organizations = organizations.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    organizations = isDescending ? organizations.OrderByDescending(x => x.Name) :
                        organizations.OrderBy(x => x.Name);
                }
                if (sortBy.Equals("NumberOfUsers"))
                {
                    organizations = isDescending ? organizations.OrderByDescending(x => x.Users.Count()) :
                        organizations.OrderBy(x => x.Users.Count());
                }
            }

            return await organizations.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Organization?> GetByIdAsync(Guid id)
        {
            return await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Organization?> UpdateAsync(Organization organizationModel)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationModel.Id);

            if (organization == null) 
            {
                return null;
            }

            _context.Organizations.Update(organizationModel);
            await _context.SaveChangesAsync();
            return organization;
        }
    }
}
