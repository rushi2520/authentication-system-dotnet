using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class LoginViewmodel
    {
        [Required(ErrorMessage = "Please Enter a Valid Email ID")]
        [DisplayName("Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remeber Me")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    }
}
