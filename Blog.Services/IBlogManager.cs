using Blog.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IBlogManager
    {
        Task<IEnumerable<BlogPost>> GetBlogPost();
        Task<BlogPost> GetBlogPost(int id);
        Task<bool> UpdateBlogPost(int id, BlogPost blogPost);
        Task<int> AddBlogPost(BlogPost blogPost);
        Task<BlogPost> DeleteBlogPost(int id);
    }
}
