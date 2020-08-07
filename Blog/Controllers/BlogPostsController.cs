using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Services;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        
        private readonly IBlogManager _blogManager;

        public BlogPostsController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPost()
        {
            try
            {
                return Ok(await _blogManager.GetBlogPost());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var blogPost = await _blogManager.GetBlogPost(id);

                if (blogPost == null)
                {
                    return NotFound();
                }

                return Ok(blogPost);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.PostId)
            {
                return BadRequest();
            }

            try
            {
                await _blogManager.UpdateBlogPost(id, blogPost);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var id = await _blogManager.AddBlogPost(blogPost);

                return CreatedAtAction("GetBlogPost", new { id = id }, blogPost);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogPost>> DeleteBlogPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var blogPost = await _blogManager.DeleteBlogPost(id);
                return Ok(blogPost);
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

    }
}
