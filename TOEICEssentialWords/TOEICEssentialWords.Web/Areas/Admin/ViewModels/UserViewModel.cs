using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TOEICEssentialWords.Model.Entities;

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

    public class UserListViewModel
    {
        public IList<UserViewModel> Users { get; set; }

        public IList<Role> AllRoles { get; set; }
    }

    public class AjaxRoleUpdateViewModel
    {
        public int Id { get; set; }
        public string[] Roles { get; set; }
    }
}