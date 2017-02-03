using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly BaseService<User> _userService;
        private readonly BaseService<Role> _roleService;

        public UserController(BaseService<User> userService, BaseService<Role> roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: Admin/User
        public override ActionResult Index()
        {
            var users = _userService.AllIncluding(u => u.Roles);
            var userListModel = new UserListViewModel
            {
                Users = Mapper.Map<IList<UserViewModel>>(users),
                AllRoles = _roleService.GetAll().ToList(),
            };

            return View(userListModel);
        }
    }
}