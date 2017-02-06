using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.ViewModels;
using System.Linq;

namespace TOEICEssentialWords.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly BaseSlugService<Word> _wordService;
        private readonly BaseService<Definition> _definitionService;

        public WordController(BaseSlugService<Word> wordService, BaseService<Definition> definitionService)
        {
            _wordService = wordService;
            _definitionService = definitionService;
        }

        public ActionResult Index(string slug)
        {
            var word = _wordService.FindBy(w => w.Slug.Equals(slug)).FirstOrDefault();
            return View(new WordViewModel
            {
                Name = word.Name,
                WordType = word.WordType.ToString(),
                BrEPronoun = word.BrEPronoun,
                BrESoundUrl = word.BrESoundUrl,
                NAmEPronoun = word.NAmEPronoun,
                NAmESoundUrl = word.NAmESoundUrl,
                Definitons = word.Definitions.ToList()
            });
        }

        public ActionResult SearchWord(string keyword)
        {
            var word = _wordService.FindBy(w => w.Name.Equals(keyword)).FirstOrDefault();

            if (word != null)
            {
                return RedirectToAction("Index", new { slug = word.Slug });
            }

            return RedirectToAction("NotFound", new { keyword = keyword });
        }

        public ActionResult NotFound(string keyword)
        {
            ViewBag.KeyWord = keyword;
            return View();
        }

        [HttpPost]
        public ActionResult AddToWordList(int wordId)
        {
            return View();
        }
    }
}