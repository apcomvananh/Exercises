using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class AdminLessonController : AdminController
    {
        private readonly BaseSlugService<Lesson> _lessonService;
        private readonly BaseService<Topic> _topicService;

        public AdminLessonController(BaseSlugService<Lesson> lessonService, BaseService<Topic> topicService)
        {
            _lessonService = lessonService;
            _topicService = topicService;
        }

        public ActionResult Manage(string search)
        {
            var lessons = string.IsNullOrEmpty(search)
                ? _lessonService.GetAll().OrderBy(l => l.LessonNumber)
                : _lessonService.FindBy(l => l.Name.Contains(search)).OrderBy(l => l.LessonNumber);

            var lessonListModel = new AdminLessonListViewModel
            {
                Search = search,
                Lessons = Mapper.Map<IList<AdminLessonViewModel>>(lessons)
            };

            return View(lessonListModel);
        }

        public PartialViewResult Create()
        {
            var viewModel = new AdminLessonViewModel { AllTopics = GetSelectListTopics() };
            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult Create(AdminLessonViewModel lessonModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lesson = new Lesson
                    {
                        LessonNumber = lessonModel.LessonNumber,
                        Name = lessonModel.Name,
                        TopicId = lessonModel.TopicId,
                    };

                    _lessonService.Add(lesson);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    lessonModel.AllTopics = GetSelectListTopics();
                    return PartialView(lessonModel);
                }
            }

            lessonModel.AllTopics = GetSelectListTopics();
            return PartialView(lessonModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var lesson = _lessonService.GetSingle(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }

            var lessonViewModel = Mapper.Map<AdminLessonViewModel>(lesson);
            lessonViewModel.AllTopics = GetSelectListTopics();

            return PartialView(lessonViewModel);
        }

        [HttpPost]
        public ActionResult Edit(AdminLessonViewModel lessonModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lesson = _lessonService.GetSingle(lessonModel.Id);

                    lesson.LessonNumber = lessonModel.LessonNumber;
                    lesson.Name = lessonModel.Name;
                    lesson.TopicId = lessonModel.TopicId;

                    _lessonService.Edit(lesson);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    lessonModel.AllTopics = GetSelectListTopics();
                    return PartialView(lessonModel);
                }
            }

            lessonModel.AllTopics = GetSelectListTopics();
            return PartialView(lessonModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var lesson = _lessonService.GetSingle(id);
                _lessonService.Delete(lesson);

                ShowGenericMessage(GenericMessages.success, "Lesson Deleted");
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
            }

            return RedirectToAction("Manage");
        }

        private IList<SelectListItem> GetSelectListTopics()
        {
            var allowedTopics = _topicService.GetAll();
            var topics = new List<SelectListItem> { new SelectListItem { Text = string.Empty, Value = string.Empty } };
            foreach (var topic in allowedTopics)
            {
                topics.Add(new SelectListItem { Text = topic.Name, Value = topic.Id.ToString() });
            }
            return topics;
        }
    }
}