using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.Models
{
    public class Users : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string? ProfilePhoto { get; set; } // store file path
    }
}
