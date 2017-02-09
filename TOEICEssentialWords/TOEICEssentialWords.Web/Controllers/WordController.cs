using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Web.Providers;
using TOEICEssentialWords.Web.ViewModels;

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
            var wordViewModel = Mapper.Map<WordViewModel>(word);
            return View(wordViewModel);
        }

        public ActionResult SearchWord(string keyword)
        {
            var word = _wordService.FindBy(w => w.Name.Equals(keyword)).FirstOrDefault();

            if (word != null)
            {
                return RedirectToAction("Index", new { slug = word.Slug });
            }

            var nearResults = _wordService.FindBy(w => w.Name.Contains(keyword)).ToList();
            var notFoundViewModel = new NotFoundWordViewModel
            {
                KeyWord = keyword,
                NearestResults = nearResults
            };

            return View("NotFound", notFoundViewModel);
        }

        [Authorize]
        [HttpPost]
        public void AddToWordList(int wordId)
        {
            if (Request.IsAjaxRequest())
            {
                var membershipService = ServiceFactory.Get<MembershipService>();
                try
                {
                    membershipService.AddWordToWordList(User.Identity.Name, _wordService.GetSingle(wordId));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}