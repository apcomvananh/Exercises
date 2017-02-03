using AutoMapper;
using System.Collections.Generic;
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

        // GET: Admin/Role
        public override ActionResult Index()
        {
            var roles = _roleService.GetAll();
            var roleListModel = new RoleListViewModel
            {
                Roles = Mapper.Map<IList<RoleViewModel>>(roles),
            };
            return View(roleListModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public ActionResult Edit(int id)
        {
            var role = _roleService.GetSingle(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Edit(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}