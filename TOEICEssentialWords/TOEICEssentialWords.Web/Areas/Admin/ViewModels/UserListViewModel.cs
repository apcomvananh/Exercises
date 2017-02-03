using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class UserListViewModel
    {
        public IList<UserViewModel> Users { get; set; }

        public IList<Role> AllRoles { get; set; }
    }
}