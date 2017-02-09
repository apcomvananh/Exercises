using System;
using System.Web.Mvc;
using System.Web.Security;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.ViewModels;

namespace TOEICEssentialWords.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly MembershipService _membershipService;

        public AccountController(MembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();

            var returnUrl = Request["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                viewModel.ReturnUrl = returnUrl;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_membershipService.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    if (Url.IsLocalUrl(model.ReturnUrl) &&
                        model.ReturnUrl.Length > 1 &&
                        model.ReturnUrl.StartsWith("/", StringComparison.CurrentCulture) &&
                        !model.ReturnUrl.StartsWith("//", StringComparison.CurrentCulture) &&
                        !model.ReturnUrl.StartsWith("/\\", StringComparison.CurrentCulture))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home", new { area = string.Empty });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect username or password");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    FirtName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Username,
                    Password = model.Password,
                    DateCreated = DateTime.UtcNow
                };

                _membershipService.CreateUser(newUser);

                if (Url.IsLocalUrl(model.ReturnUrl) &&
                        model.ReturnUrl.Length > 1 &&
                        model.ReturnUrl.StartsWith("/", StringComparison.CurrentCulture) &&
                        !model.ReturnUrl.StartsWith("//", StringComparison.CurrentCulture) &&
                        !model.ReturnUrl.StartsWith("/\\", StringComparison.CurrentCulture))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}