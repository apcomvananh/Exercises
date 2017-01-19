using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index(int id)
        {
            var lesson = _lessonService.GetSingle(id);
            var wordsToLearn = _wordService.FindBy(w => w.LessonId.Equals(id));

            return View(new LessonViewModel { Lesson = lesson, WordsToLearn = wordsToLearn });
        }
    }
}