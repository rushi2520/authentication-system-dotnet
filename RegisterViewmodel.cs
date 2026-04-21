using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class RegisterViewmodel
    {
        [Required]
        [DisplayName("Enter Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Enter Surname")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Correct Email Id")]
        [DisplayName("Email ID")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Enter Contact Number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at least {2} and at max{1}")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
 ErrorMessage = "Password must contain uppercase, lowercase, number, and special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }

        public IFormFile? Profile_photo { get; set; }
    }
}
