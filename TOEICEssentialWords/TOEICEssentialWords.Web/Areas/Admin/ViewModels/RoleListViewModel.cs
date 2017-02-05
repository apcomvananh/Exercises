using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class RoleListViewModel
    {
        public IList<Role> Roles { get; set; }
    }
}