using BlogAPI.Models;

namespace BlogAPI.Services
{
    public interface IBlogPostService
    {
        bool AddBlogPost(BlogPost blogPost);
        List<BlogPost> GetAllBlogPost();
        List<BlogPost> GetBlogPosts(int userId);
        BlogPost GetBlogPostById(int id);
        bool UpdateBlogPost(BlogPost blogPost);
        bool DeleteBlogPost(BlogPost blogPost);
    }
}
