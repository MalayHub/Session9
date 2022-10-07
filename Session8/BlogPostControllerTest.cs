using BlogAPI.Controllers;
using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Session8.Services;

namespace Session8
{
    public class BlogPostControllerTest
    {
        private readonly BlogPostController _controller;
        private readonly IBlogPostService _service;
        public BlogPostControllerTest()
        {
            _service = new BlogPostServiceFake();
            _controller = new BlogPostController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllBlogPost();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAllBlogPost() as OkObjectResult;
            // Assert
            var blogs = Assert.IsType<List<BlogPost>>(okResult.Value);
            Assert.Equal(2, blogs.Count);
        }
    }
}