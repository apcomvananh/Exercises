using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class RegisterViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}