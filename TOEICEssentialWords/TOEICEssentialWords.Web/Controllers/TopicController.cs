using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.ViewModels;

namespace TOEICEssentialWords.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly BaseService<Topic> _topicService;

        public TopicController(BaseService<Topic> topicService)
        {
            _topicService = topicService;
        }

        public PartialViewResult TopicMenu()
        {
            var topics = _topicService.GetAll().OrderBy(x => x.Index);

            return PartialView(new TopicMenuViewModel
            {
                Topics = Mapper.Map<IList<TopicViewModel>>(topics)
            });
        }
    }
}