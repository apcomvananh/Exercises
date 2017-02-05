using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class RoleController : AdminController
    {
        private readonly BaseService<Role> _roleService;

        public RoleController(BaseService<Role> roleService)
        {
            _roleService = roleService;
        }

        public override ActionResult Index()
        {
            var roles = _roleService.GetAll();

            var roleListModel = new RoleListViewModel
            {
                Roles = roles.ToList(),
            };

            return View(roleListModel);
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = new Role
                    {
                        Name = roleModel.Name
                    };

                    _roleService.Add(role);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(roleModel);
                }
            }
            return PartialView(roleModel);
        }

        public PartialViewResult Edit(int id)
        {
            var role = _roleService.GetSingle(id);
            var roleModel = Mapper.Map<RoleViewModel>(role);
            return PartialView(roleModel);
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = _roleService.GetSingle(roleModel.Id);
                    role.Name = roleModel.Name;
                    _roleService.Edit(role);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(roleModel);
                }
            }

            return PartialView(roleModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var role = _roleService.GetSingle(id);
                _roleService.Delete(role);

                ShowGenericMessage(GenericMessages.success, "Role Deleted");
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}