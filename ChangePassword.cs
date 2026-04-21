using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Enter Email ID")]
        [EmailAddress]
        [DisplayName("Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Current Password")]
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        public string Current_Password { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at least {2} and at max {1}")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number, and special character")]
        [DisplayName("New Password")]
        public string New_Password { get; set; }

        [Required(ErrorMessage = "Enter Current Password")]
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
