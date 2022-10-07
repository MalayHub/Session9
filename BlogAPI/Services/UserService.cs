using BlogAPI.Context;
using BlogAPI.Models;

namespace BlogAPI.Services
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _userDbContext;
        public UserService(ApplicationDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public User GetUserByEmail(string email)
        {
            return _userDbContext.UserTbl.FirstOrDefault(user => user.Email == email);
        }

        public bool RegisterUser(User user)
        {
            _userDbContext.UserTbl.Add(user);
            return _userDbContext.SaveChanges() == 1;
        }
    }
}
