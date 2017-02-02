using System.Web.Mvc;
using System.Linq;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.ViewModels;

namespace TOEICEssentialWords.Web.Controllers
{
    public class LessonController : Controller
    {
        private readonly BaseService<Lesson> _lessonService;
        private readonly BaseService<Word> _wordService;

        public LessonController(BaseService<Lesson> lessonService, BaseService<Word> wordService)
        {
            _lessonService = lessonService;
            _wordService = wordService;
        }

        // GET: Lesson
        public ActionResult Index(string slug)
        {
            var lesson = _lessonService.FindBy(l => l.Slug.Equals(slug)).FirstOrDefault();
            var wordsToLearn = _wordService.FindBy(w => w.LessonId.Equals(lesson.Id));
            var relatedLessons = _lessonService.FindBy(l => l.TopicId == lesson.TopicId && l.Id != lesson.Id);

            return View(new LessonViewModel { Name = lesson.Name, TopicName = lesson.Topic.Name, WordsToLearn = wordsToLearn, RelatedLessons = relatedLessons });
        }
    }
}