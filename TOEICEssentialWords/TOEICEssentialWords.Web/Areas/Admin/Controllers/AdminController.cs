using System.Web.Mvc;
using TOEICEssentialWords.Model;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AppConstants.AdminRoleName)]
    public class AdminController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        protected void ShowGenericMessage(GenericMessages messageType, string message)
        {
            TempData[AppConstants.MessageViewBagName] = new GenericMessageViewModel
            {
                Message = message,
                MessageType = messageType
            };
        }
    }
}