namespace BlogAPI.Services
{
    public interface ITokenService
    {
        public string CreateToken(string email);
    }
}