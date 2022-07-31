using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repository;

using ShoppingCart.Model;
using ShoppingCart.Models;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IShoppingCartRepository<Products> productRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IShoppingCartRepository<Products> productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var product = productRepository.List();
            return View(product);
        }
        public ActionResult Details(int id)
        {
            Cart cart = new Cart()
            {
                Products = productRepository.Find(id),
                Count = 1,
                ProductId = id
            };
            return View(cart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}