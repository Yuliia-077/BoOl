using Microsoft.AspNetCore.Identity;

namespace BoOl.Domain
{
    public class User: IdentityUser
    {
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
