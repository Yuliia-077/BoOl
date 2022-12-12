using System.Collections.Generic;

namespace BoOl.Application.Models.Users
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public int WorkerId { get; set; }
        public string Password { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
