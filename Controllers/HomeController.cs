using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string Search="", int CategoryID = 0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(Search, CategoryID);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            ProductDisplayModel productDisplayModel = new ProductDisplayModel
            {
                Products = products,
                Categories = categories,
                Search = Search,
                CategoryID = CategoryID
            };
            return View(productDisplayModel);
        }
        
        /* public IActionResult Privacy()
         {
             return View();
         }

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
         {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }*/
    }
}
