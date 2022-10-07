namespace BlogAPI.Services
{
    public class RefreshToken
    {
        public string Token { get; set; } = String.Empty;
        public DateTime Expires {get;set; } = DateTime.Now;
        public DateTime Created { get; set; }
    }
}
