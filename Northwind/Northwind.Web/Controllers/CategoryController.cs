namespace Northwind.Web.Controllers
{
    using Core.Model;
    using Core.Services;
    using Core.Services.Implementations;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels;

    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryServiceImp();
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(new CategoryListViewModel { Categories = categories });
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Get(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Description = model.Description,
                    Picture = model.Picture
                };

                _categoryService.AddCategory(category);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Get(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryService.Get(model.Id);

                category.Name = model.Name;
                category.Description = model.Description;

                _categoryService.Edit(category);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryService.Get(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}