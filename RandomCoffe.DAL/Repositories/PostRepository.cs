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
    internal class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Post> CreateAsync(Post postModel)
        {
            await _context.Posts.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<Post?> DeleteAsync(Guid id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return null;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Posts.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Post>> GetAllAsync(Guid organizationId)
        {
            return await _context.Posts.Where(x => x.OrganizationId == organizationId).ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post?> UpdateAsync(Post postModel)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == postModel.Id);
            if (post == null)
            {
                return null;
            }

            _context.Posts.Update(postModel);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
