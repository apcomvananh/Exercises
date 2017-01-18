using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly BaseService<Topic> _topicService;

        public TopicController(BaseService<Topic> topicService)
        {
            _topicService = topicService;
        }

        // GET: Topic
        public ActionResult Index()
        {
            var topics = _topicService.GetAll();
            return View(topics);
        }
    }
}