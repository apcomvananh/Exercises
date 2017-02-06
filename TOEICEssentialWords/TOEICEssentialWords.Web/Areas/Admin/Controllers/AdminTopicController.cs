using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class AdminTopicController : AdminController
    {
        private readonly BaseService<Topic> _topicService;

        public AdminTopicController(BaseService<Topic> topicService)
        {
            _topicService = topicService;
        }

        // GET: Admin/Topic
        public override ActionResult Index()
        {
            var topics = _topicService.GetAll().OrderBy(t => t.Index);
            var topicListModel = new AdminTopicListViewModel
            {
                Topics = topics.ToList()
            };

            return View(topicListModel);
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Topic/Create
        [HttpPost]
        public ActionResult Create(AdminTopicViewModel topicModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var topic = new Topic
                    {
                        Name = topicModel.Name,
                        Index = topicModel.Index,
                    };

                    _topicService.Add(topic);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(topicModel);
                }
            }
            return PartialView(topicModel);
        }

        // GET: Admin/Topic/Edit/5
        public PartialViewResult Edit(int id)
        {
            var topic = _topicService.GetSingle(id);
            var topicModel = Mapper.Map<AdminTopicViewModel>(topic);

            return PartialView(topicModel);
        }

        // POST: Admin/Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(AdminTopicViewModel topicModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var topic = _topicService.GetSingle(topicModel.Id);
                    topic.Name = topicModel.Name;
                    topic.Index = topicModel.Index;

                    _topicService.Edit(topic);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return PartialView(topicModel);
                }
            }

            return PartialView(topicModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var role = _topicService.GetSingle(id);
                _topicService.Delete(role);

                ShowGenericMessage(GenericMessages.success, "Topic Deleted");
            }
            catch (Exception ex)
            {
                ShowGenericMessage(GenericMessages.danger, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}