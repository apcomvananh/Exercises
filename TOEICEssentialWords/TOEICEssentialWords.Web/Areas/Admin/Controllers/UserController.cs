using AutoMapper;
using System;
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

        [HttpPost]
        public void UpdateUserRoles(AjaxRoleUpdateViewModel ajaxRoleUpdateViewModel)
        {
            if (Request.IsAjaxRequest())
            {
                var user = _userService.AllIncluding(u => u.Roles).Where(u => u.Id == ajaxRoleUpdateViewModel.Id).FirstOrDefault();

                try
                {
                    UpdateUserRoles(user, ajaxRoleUpdateViewModel.Roles);
                    _userService.Edit(user);
                }
                catch (Exception ex)
                {
                    ShowGenericMessage(GenericMessages.danger, ex.Message);
                }
            }
        }

        private void UpdateUserRoles(User user, IEnumerable<string> updatedRoles)
        {
            var updatedRolesSet = new List<Role>();
            foreach (var roleStr in updatedRoles)
            {
                var alreadyIsRoleForUser = false;
                foreach (var role in user.Roles)
                {
                    if (roleStr == role.Name)
                    {
                        updatedRolesSet.Add(role);
                        alreadyIsRoleForUser = true;
                        break;
                    }
                }

                if (!alreadyIsRoleForUser)
                {
                    updatedRolesSet.Add(_roleService.FindBy(r => r.Name.Equals(roleStr)).FirstOrDefault());
                }
            }

            user.Roles.Clear();
            foreach (var role in updatedRolesSet)
            {
                user.Roles.Add(role);
            }
        }
    }
}