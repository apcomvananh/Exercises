﻿using System.Web.Mvc;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}