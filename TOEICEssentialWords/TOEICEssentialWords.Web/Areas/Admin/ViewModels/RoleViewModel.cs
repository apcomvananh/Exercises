using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Role name")]
        public string Name { get; set; }
    }
}