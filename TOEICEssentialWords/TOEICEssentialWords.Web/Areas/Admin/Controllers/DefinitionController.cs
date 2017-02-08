using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class DefinitionController : AdminController
    {
        public BaseService<Definition> _definitionService;

        public DefinitionController(BaseService<Definition> definitionService)
        {
            this._definitionService = definitionService;
        }

        // GET: Admin/Definition
        public ActionResult ListDefinitions(int wordId)
        {
            var definitions = _definitionService.FindBy(d => d.WordId == wordId);
            var definitionListModel = new DefinitionListViewModel
            {
                WordId = wordId,
                Definitions = Mapper.Map<IList<DefinitionViewModel>>(definitions)
            };

            return PartialView(definitionListModel);
        }

        public PartialViewResult Create(int wordId)
        {
            return PartialView(new DefinitionViewModel { WordId = wordId });
        }

        [HttpPost]
        public ActionResult Create(DefinitionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var definition = new Definition
                    {
                        Name = model.Name,
                        Example = model.Example,
                        WordId = model.WordId
                    };
                    _definitionService.Add(definition);

                    return Json(new { success = true, wordId = model.WordId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(model);
                }
            }
            return PartialView(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var definition = _definitionService.GetSingle(id.Value);
            if (definition == null)
            {
                return HttpNotFound();
            }

            var definitionModel = Mapper.Map<DefinitionViewModel>(definition);

            return PartialView(definitionModel);
        }

        [HttpPost]
        public ActionResult Edit(DefinitionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var definition = _definitionService.GetSingle(model.Id);

                    definition.Name = model.Name;
                    definition.Example = model.Example;
                    definition.WordId = model.WordId;
                    _definitionService.Edit(definition);

                    return Json(new { success = true, wordId = model.WordId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(model);
                }
            }

            return PartialView(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var definition = _definitionService.GetSingle(id.Value);
            if (definition == null)
            {
                return HttpNotFound();
            }

            try
            {
                _definitionService.Delete(definition);
                return Json(new { success = true, wordId = definition.WordId });
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
                return Json(new { success = false });
            }
        }
    }
}