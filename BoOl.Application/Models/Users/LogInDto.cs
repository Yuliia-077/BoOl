namespace BoOl.Application.Models.Users
{
    public class LogInDto
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
