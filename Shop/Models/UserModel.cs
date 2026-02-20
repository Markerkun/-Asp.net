using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserModel: IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }


    }
}