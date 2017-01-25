using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly BaseService<User> _userService;

        public UserController(BaseService<User> userService)
        {
            _userService = userService;
        }

        // GET: Admin/User
        public override ActionResult Index()
        {
            var users = _userService.AllIncluding(u => u.Roles);
            return View(users);
        }
    }
}