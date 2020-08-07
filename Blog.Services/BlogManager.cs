
using Blog.DataAccess;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class BlogManager : IBlogManager
    {
        private readonly BlogContext _context;
        private readonly IDataRepository<BlogPost> _repo;

        public BlogManager(BlogContext context, IDataRepository<BlogPost> repo)
        {
            _context = context;
            _repo = repo;
        }
        public async Task<BlogPost> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return blogPost;
            }

            try
            {
                _repo.Delete(blogPost);
                var save = await _repo.SaveAsync(blogPost);

                return save;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPost()
        {
            try
            {
                return await _context.BlogPost.OrderByDescending(x => x.PostId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BlogPost> GetBlogPost(int id)
        {
            try
            {
                return await _context.BlogPost.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> AddBlogPost(BlogPost blogPost)
        {
            try
            {
                _repo.Add(blogPost);
                var save = await _repo.SaveAsync(blogPost);
                return save.PostId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateBlogPost(int id, BlogPost blogPost)
        {
            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                _repo.Update(blogPost);
                var save = await _repo.SaveAsync(blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool BlogPostExists(int id)
        {
            try
            {
                return _context.BlogPost.Any(e => e.PostId == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
