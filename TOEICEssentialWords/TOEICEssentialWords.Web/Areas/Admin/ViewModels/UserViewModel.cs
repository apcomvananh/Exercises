using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirtName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("Roles")]
        public string[] Roles { get; set; }
    }
}