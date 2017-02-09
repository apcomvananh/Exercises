using System.Linq;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        private readonly BaseSlugService<Word> _wordService;
        private readonly BaseSlugService<Lesson> _lessonService;
        private readonly BaseService<Topic> _topicService;

        public DashboardController(
            BaseService<Topic> topicService,
            BaseSlugService<Lesson> lessonService,
            BaseSlugService<Word> wordService)
        {
            _topicService = topicService;
            _lessonService = lessonService;
            _wordService = wordService;
        }

        public PartialViewResult Dashboard()
        {
            var dashboardViewModel = new DashboardViewModel
            {
                TotalTopics = _topicService.GetAll().Count(),
                TotalLessons = _lessonService.GetAll().Count(),
                TotalWords = _wordService.GetAll().Count(),
            };

            return PartialView(dashboardViewModel);
        }
    }
}