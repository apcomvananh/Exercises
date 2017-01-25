using System.ComponentModel.DataAnnotations;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}