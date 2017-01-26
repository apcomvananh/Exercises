using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.ViewModels;
using System.Linq;

namespace TOEICEssentialWords.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly BaseService<Word> _wordService;
        private readonly BaseService<Definition> _definitionService;

        public WordController(BaseService<Word> wordService, BaseService<Definition> definitionService)
        {
            _wordService = wordService;
            _definitionService = definitionService;
        }

        public ActionResult Index(int id)
        {
            var word = _wordService.GetSingle(id);
            return View(new WordViewModel
            {
                Name = word.Name,
                WordType = word.WordType.ToString(),
                BrEPronoun = word.BrEPronoun,
                NAmEPronoun = word.NAmEPronoun,
                Definitons = word.Definitions.ToList()
            });
        }

        public ActionResult SearchWord(string searchWord)
        {
            var word = _wordService.FindBy(w => w.Name.Equals(searchWord)).FirstOrDefault();
            if (word != null)
            {
                return RedirectToAction("Index", new { id = word.Id });
            }
            return RedirectToAction("NotFound");
        }

        public ActionResult NotFound()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToWordList(int wordId)
        {
            return View();
        }
    }
}