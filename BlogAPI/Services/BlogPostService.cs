using BlogAPI.Context;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services
{
    public class BlogPostService: IBlogPostService
    {
        private readonly ApplicationDbContext _blogPostDbContext;
        public BlogPostService(ApplicationDbContext blogPostDbContext)
        {
            _blogPostDbContext = blogPostDbContext;
        }

        public bool AddBlogPost(BlogPost blogPost)
        {
            _blogPostDbContext.BlogPostTbl.Add(blogPost);
            return _blogPostDbContext.SaveChanges() == 1;
        }

        public List<BlogPost> GetAllBlogPost()
        {
            return _blogPostDbContext.BlogPostTbl.Where(b=>b.IsDeleted==false).Include(b=>b.User).ToList();
        }

        public List<BlogPost> GetBlogPosts(int userId)
        {
            return _blogPostDbContext.BlogPostTbl.Where(b => b.IsDeleted == false && b.UserId == userId).Include(b => b.User).ToList();
        }

        public BlogPost GetBlogPostById(int id)
        {
            return _blogPostDbContext.BlogPostTbl.FirstOrDefault(b => b.IsDeleted == false && b.Id == id);
        }

        public bool UpdateBlogPost(BlogPost blogPost)
        {
            _blogPostDbContext.Entry<BlogPost>(blogPost).State = EntityState.Modified;
            return _blogPostDbContext.SaveChanges() == 1;
        }

        public bool DeleteBlogPost(BlogPost blogPost)
        {
            blogPost.IsDeleted = true;
            _blogPostDbContext.Entry<BlogPost>(blogPost).State = EntityState.Modified;
            return _blogPostDbContext.SaveChanges() == 1;
        }
    }
}
