using Microsoft.AspNetCore.Identity;
using Servicebook.Helper;

namespace Servicebook.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role role { get; set; } = Role.User;
    }
}