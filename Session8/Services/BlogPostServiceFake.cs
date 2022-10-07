using BlogAPI.Context;
using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session8.Services
{
    public class BlogPostServiceFake : IBlogPostService
    {
        List<BlogPost> posts;
        public BlogPostServiceFake()
        {
            posts = new List<BlogPost>()
            {
                new BlogPost(){Id=1, Title="14 Peaks: Nothing is Impossible!", Content="<p><span style=\"color: #464646; font-family: 'comic sans ms', sans-serif; font-size: 19.2px; background-color: #ffffff;\">This documentary on Netflix follows <span style=\"font-size: 18pt;\"><em>The ambitious project of</em></span></span> <span style=\"color: #464646; font-family: 'comic sans ms', sans-serif; font-size: 19.2px; background-color: #ffffff;\"><span style=\"font-size: 18pt;\"><em><span style=\"background-color: #fefe02;\">Nirmal Purja</span></em></span></span> <span style=\"color: #464646; font-family: 'comic sans ms', sans-serif; font-size: 19.2px; background-color: #ffffff;\">(a Nepali mountaineer) of breaking records in mountaineering! It will take you through an emotional journey that will redefine the <strong>\"Impossible\"</strong> and convince you to look beyond your circumstances (which at times restrict us because of our own thinking). This is a good watch for those instances when you start defining your ambitions with the perspectives of those around you (when perhaps it is not needed)!</span></p>"
                    ,UserId=1, CreatedOn=DateTime.Now, CreatedBy=1, IsDeleted = false, User = new User(){
                        UserId=1, Email="malay@mail.com", UserName="Malay Satiya", Password="", ConfirmPassword=""
                        , CreatedOn=DateTime.Now, CreatedBy = "malay@mail.com", IsDeleted=false} },
                new BlogPost(){Id=2, Title="Team India Secures Emphatic 10-Wicket Over Zimbabwe In The 1st ODI", Content="<p dir=\"ltr\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: Poppins; font-size: 16px; background-color: #ffffff;\"><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: inherit; font-style: inherit; font-weight: 600;\">Team India thrashes Zimbabwe-&nbsp;<a style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: inherit; font-style: inherit; font-weight: inherit; background-color: transparent; color: #000000; text-decoration-line: none; transition: all 0.3s ease 0s;\" href=\"https://kricketwicket.com/3-reasons-india-lost-to-australia-commonwealth-games/\">India&rsquo;s</a></span>&nbsp;juggernaut keeps on rolling. After trouncing England and West Indies, this time it&rsquo;s Zimbabwe who are bearing the brunt of this unit. In the first of the 3-match series between the two sides, India comprehensively got the better of Zimbabwe, beating them by 10 wickets and taking a 1-0 lead in the series. After winning the toss and opting to bowl first, the Indian seamers made full use of the seating conditions on offer and the Zimbabwe batsmen were no match for the lethal bowling of&nbsp;<a style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: inherit; font-style: inherit; font-weight: inherit; background-color: transparent; color: #000000; text-decoration-line: none; transition: all 0.3s ease 0s;\" href=\"https://en.wikipedia.org/wiki/Deepak_Chahar\"><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: inherit; font-style: inherit; font-weight: 600;\">Deepak Chahar,</span></a>&nbsp;having been reduced for 31-4, and then 110-8.</p>\r\n<p dir=\"ltr\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: Poppins; font-size: 16px; background-color: #ffffff;\">&nbsp;</p>\r\n<p dir=\"ltr\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; outline: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; vertical-align: baseline; font-family: Poppins; font-size: 16px; background-color: #ffffff;\">It could have been worse, if not for a 9th wicket stand of 70 runs between Brad Evans and Ngrava which lent the score some semblance of respectability. However, a target of 190 was never going to be a tall order, and Dhawan and Gill did just that, making a mockery of the target and easily achieving the target with almost 19 overs to spare.</p>"
                    ,UserId=2, CreatedOn=DateTime.Now, CreatedBy=2, IsDeleted = false, User = new User(){
                        UserId=2, Email="aniket@mail.com", UserName="Aniket Maurya", Password="", ConfirmPassword=""
                        , CreatedOn=DateTime.Now, CreatedBy = "aniket@mail.com", IsDeleted=false} },
            };
        }

        public bool AddBlogPost(BlogPost blogPost)
        {
            posts.Add(blogPost);
            return true;
        }

        public List<BlogPost> GetAllBlogPost()
        {
            return posts.Where(b => b.IsDeleted == false).ToList();
        }

        public List<BlogPost> GetBlogPosts(int userId)
        {
            return posts.Where(b => b.IsDeleted == false && b.UserId == userId).ToList();
        }

        public BlogPost GetBlogPostById(int id)
        {
            return posts.FirstOrDefault(b => b.IsDeleted == false && b.Id == id);
        }

        public bool UpdateBlogPost(BlogPost blogPost)
        {
            posts.FirstOrDefault(b => b.Id == blogPost.Id).Title = blogPost.Title;
            posts.FirstOrDefault(b => b.Id == blogPost.Id).Content = blogPost.Content;
            return true;
        }

        public bool DeleteBlogPost(BlogPost blogPost)
        {
            posts.FirstOrDefault(b => b.Id == blogPost.Id).IsDeleted = true;
            return true;
        }
    }
}
