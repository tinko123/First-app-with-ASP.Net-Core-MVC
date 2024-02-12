using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCIntroDemo.Core.Contracts;
using MVCIntroDemo.Core.Models;
using MVCIntroDemo.Infrastructure.Data;
using MVCIntroDemo.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Core.Services
{
    public class PostService : IPostService
    {
        private readonly MVCIntroDemoDbContext context;
        private readonly ILogger logger;
        public PostService(
            MVCIntroDemoDbContext _context,
            ILogger<PostService> _logger)
        {
            logger = _logger;
            context = _context;
        }

        public async Task AddAsync(PostModels model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };
            try
            {
                await context.Posts.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "PostService.AddAsync");
                throw new ApplicationException("Operation failed. Please, try again");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.FindAsync<Post>(id);
            if (entity == null)
            {
                throw new ApplicationException("Invalid post");
            }
            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(PostModels model)
        {
            var entity = await context.FindAsync<Post>(model.Id);
            if (entity == null)
            {
                throw new ApplicationException("Invalid post");
            }
            entity.Title = model.Title;
            entity.Content = model.Content;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModels>> GetAllPostsAsync()
        {
            return await context.Posts
                .Select(p => new PostModels()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PostModels?> GetPostByIdAsync(int id)
        {
            return await context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostModels()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
