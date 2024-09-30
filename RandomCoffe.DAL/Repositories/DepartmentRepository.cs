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
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Department> CreateAsync(Department departmentModel)
        {
            await _context.Departments.AddAsync(departmentModel);
            await _context.SaveChangesAsync();
            return departmentModel;
        }

        public async Task<Department?> DeleteAsync(Guid id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                return null;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Departments.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(Guid id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department?> UpdateAsync(Department departmentModel)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == departmentModel.Id);
            if (department == null)
            {
                return null;
            }

            _context.Update(departmentModel);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
