using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BoOl.Models
{
    public class User: IdentityUser
    {
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
