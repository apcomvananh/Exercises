using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly BaseService<Word> _wordService;

        public WordController(BaseService<Word> wordService)
        {
            _wordService = wordService;
        }

        public ActionResult Index(int id)
        {
            var word = _wordService.GetSingle(id);
            return View(word);
        }
    }
}