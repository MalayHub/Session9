using BlogAPI.Models;

namespace BlogAPI.Services
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        User GetUserByEmail(string email);
    }
}
