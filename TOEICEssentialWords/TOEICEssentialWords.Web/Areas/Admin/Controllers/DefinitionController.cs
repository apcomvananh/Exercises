using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class DefinitionController : Controller
    {
        public BaseService<Definition> _definitionService;

        public DefinitionController(BaseService<Definition> definitionService)
        {
            this._definitionService = definitionService;
        }

        // GET: Admin/Definition
        public ActionResult Index(int id)
        {
            var definitions = _definitionService.FindBy(d => d.WordId == id);
            return PartialView(definitions);
        }

        public ActionResult Create(int wordId)
        {
            var definition = new Definition
            {
                WordId = wordId
            };
            return PartialView(definition);
        }

        [HttpPost]
        public ActionResult Create(Definition model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _definitionService.Add(model);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(model);
                }
            }
            return PartialView(model);
        }

        public ActionResult Edit(int id)
        {
            var definition = _definitionService.GetSingle(id);

            if (definition == null)
            {
                return HttpNotFound();
            }

            return PartialView(definition);
        }

        [HttpPost]
        public ActionResult Edit(Definition model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _definitionService.Edit(model);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(model);
                }
            }

            return PartialView(model);
        }
    }
}