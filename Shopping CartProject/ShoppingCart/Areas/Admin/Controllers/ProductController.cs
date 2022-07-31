using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repository;
using ShoppingCart.DataAccess.ShoppingCartVM;
using ShoppingCart.Model;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IShoppingCartRepository<Products> productRepository;
        private readonly IShoppingCartRepository<ProductsCategories> categoryRepository;

        public ProductController(IShoppingCartRepository<Products> productRepository, IShoppingCartRepository<ProductsCategories> categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var product = productRepository.List();
            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product =productRepository.Find(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var model = new ProductVM
            {
                productsCategories = FillSelectList()
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM Model)
        {
            try
            {  if(Model.CategoriesId==-1)
                {
                    ViewBag.Message = "Please select acategorier from the list";
                    var model = new ProductVM
                    {
                        productsCategories = FillSelectList()
                    };
                   return View(model);
                }
                
                Products products = new Products
                {
                    Id = Model.Id,
                    Name = Model.Name,
                    Code = Model.Code,
                    Price = Model.Price,
                    DiscountPercentage = Model.DiscountPercentage,
                    CreatedAt = Model.CreatedAt,
                    productsCategories = categoryRepository.Find(Model.CategoriesId)

                };
                productRepository.Add(products);
            
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var products = productRepository.Find(id);
            var categoryid = products.productsCategories == null ? products.productsCategories.Id = 0 : products.productsCategories.Id;
            var productVM = new ProductVM
            {
                Id = products.Id,
                Name = products.Name,
                Code = products.Code,
                Price = products.Price,
                DiscountPercentage = products.DiscountPercentage,
                CreatedAt = products.CreatedAt,
                CategoriesId = categoryid,
                productsCategories = FillSelectList()
            };
            return View(productVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductVM Model)
        {
            try
            {

                Products products = new Products
                {
                    Id = Model.Id,
                    Name = Model.Name,
                    Code = Model.Code,
                    Price = Model.Price,
                    DiscountPercentage = Model.DiscountPercentage,
                    CreatedAt = Model.CreatedAt,
                    productsCategories = categoryRepository.Find(Model.CategoriesId)

                };
                productRepository.Update(Model.Id,products);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var products = productRepository.Find(id);
            return View(products);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                productRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<ProductsCategories> FillSelectList()
        {
            var category = categoryRepository.List().ToList();
            category.Insert(0, new ProductsCategories { Id=-1,CategoriesName="--- Plase Select a category ---"});
            return category;
        }
    }
}
