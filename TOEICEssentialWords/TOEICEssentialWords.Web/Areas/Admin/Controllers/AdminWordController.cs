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
    public class AdminWordController : AdminController
    {
        private readonly BaseSlugService<Word> _wordService;
        private readonly BaseSlugService<Lesson> _lessonService;

        public AdminWordController(BaseSlugService<Word> wordService, BaseSlugService<Lesson> lessonService)
        {
            _wordService = wordService;
            _lessonService = lessonService;
        }

        public override ActionResult Index()
        {
            var words = _wordService.GetAll();

            var wordListModel = new AdminWordListViewModel
            {
                Words = Mapper.Map<IList<AdminWordViewModel>>(words)
            };

            return View(wordListModel);
        }

        public PartialViewResult Create()
        {
            var wordViewModel = new AdminWordViewModel { AllLessons = GetSelectListLessons() };
            return PartialView(wordViewModel);
        }

        [HttpPost]
        public ActionResult Create(AdminWordViewModel wordModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var word = new Word
                    {
                        Name = wordModel.Name,
                        WordType = wordModel.WordType,
                        BrEPronoun = wordModel.BrEPronoun,
                        BrESoundUrl = wordModel.BrESoundUrl,
                        NAmEPronoun = wordModel.NAmEPronoun,
                        NAmESoundUrl = wordModel.NAmESoundUrl,
                        LessonId = wordModel.LessonId
                    };

                    _wordService.Add(word);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    wordModel.AllLessons = GetSelectListLessons();

                    return PartialView(wordModel);
                }
            }
            wordModel.AllLessons = GetSelectListLessons();
            return PartialView(wordModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var word = _wordService.GetSingle(id.Value);
            if (word == null)
            {
                return HttpNotFound();
            }

            var wordModel = Mapper.Map<AdminWordViewModel>(word);
            wordModel.AllLessons = GetSelectListLessons();

            return View(wordModel);
        }

        [HttpPost]
        public ActionResult Edit(AdminWordViewModel wordModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var word = _wordService.GetSingle(wordModel.Id);

                    word.Name = wordModel.Name;
                    word.WordType = wordModel.WordType;
                    word.BrEPronoun = wordModel.BrEPronoun;
                    word.BrESoundUrl = wordModel.BrESoundUrl;
                    word.NAmEPronoun = wordModel.NAmEPronoun;
                    word.NAmESoundUrl = wordModel.NAmESoundUrl;
                    _wordService.Edit(word);

                    ShowGenericMessage(GenericMessages.success, "Word saved");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    wordModel.AllLessons = GetSelectListLessons();
                    return View(wordModel);
                }
            }

            wordModel.AllLessons = GetSelectListLessons();

            return View(wordModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var word = _wordService.GetSingle(id);
                _wordService.Delete(word);

                ShowGenericMessage(GenericMessages.success, "Word Deleted");
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
            }

            return RedirectToAction("Index");
        }

        private IList<SelectListItem> GetSelectListLessons()
        {
            var allowedLessons = _lessonService.GetAll();
            var lessons = new List<SelectListItem> { new SelectListItem { Text = string.Empty, Value = string.Empty } };
            foreach (var lesson in allowedLessons)
            {
                lessons.Add(new SelectListItem { Text = lesson.Name, Value = lesson.Id.ToString() });
            }
            return lessons;
        }
    }
}