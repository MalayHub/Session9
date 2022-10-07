using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        [HttpGet]
        [Route("GetAllBlogPost")]
        public IActionResult GetAllBlogPost()
        {
            return Ok(_blogPostService.GetAllBlogPost());
        }
        [HttpGet]
        [Route("GetBlogPosts/{userId:int}")]
        public IActionResult GetBlogPosts(int userId)
        {
            return Ok(_blogPostService.GetBlogPosts(userId));
        }
        [HttpGet]
        [Route("GetBlogPostById/{id:int}")]
        public IActionResult GetBlogPostById(int id)
        {
            return Ok(_blogPostService.GetBlogPostById(id));
        }
    }
}
