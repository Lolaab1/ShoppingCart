using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repository;
using ShoppingCart.Model;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IShoppingCartRepository<ProductsCategories> categoryRepository;

        public CategoryController(IShoppingCartRepository<ProductsCategories> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

       
        // GET: CategoryController
        public ActionResult Index()
        {
            var category = categoryRepository.List();
            return View(category);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var categories = categoryRepository.Find(id);
            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsCategories category)
        {
            try
            {
                categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            //var category=categoryRepository.Find(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
