using AutoMapper;
using System;
using System.Linq;
using System.Net;
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

        public ActionResult Manage()
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = _roleService.GetSingle(id.Value);
            if (role == null)
            {
                return HttpNotFound();
            }

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

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = _roleService.GetSingle(id.Value);
            if (role == null)
            {
                return HttpNotFound();
            }

            try
            {
                _roleService.Delete(role);
                ShowGenericMessage(GenericMessages.success, "Role Deleted");
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
            }

            return RedirectToAction("Manage");
        }
    }
}