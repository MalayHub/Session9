using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/BlogPost2")]
    [ApiController]
    [ApiVersion("2")]
    public class BlogPost2Controller : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPost2Controller(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        [HttpGet]
        [Route("GetAllBlogPost")]
        [Authorize]
        public IActionResult GetAllBlogPost()
        {
            return Ok(_blogPostService.GetAllBlogPost());
        }
        [HttpGet]
        [Route("GetBlogPosts/{userId:int}")]
        [Authorize]
        public IActionResult GetBlogPosts(int userId)
        {
            return Ok(_blogPostService.GetBlogPosts(userId));
        }
        [HttpGet]
        [Route("GetBlogPostById/{id:int}")]
        [Authorize]
        public IActionResult GetBlogPostById(int id)
        {
            return Ok(_blogPostService.GetBlogPostById(id));
        }
        [HttpPost]
        [Route("AddBlogPost")]
        [Authorize]
        public IActionResult AddBlogPost(BlogPost blogPost)
        {
            blogPost.CreatedBy = blogPost.UserId;
            blogPost.CreatedOn = DateTime.Now;
            return Ok(_blogPostService.AddBlogPost(blogPost));
        }
    }
}
