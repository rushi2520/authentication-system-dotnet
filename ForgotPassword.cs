using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Enter Email ID")]
        [EmailAddress]
        [DisplayName("Email ID")]
        public string Email { get; set; }
    }
}
