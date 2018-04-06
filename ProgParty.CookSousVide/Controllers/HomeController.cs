using Microsoft.AspNetCore.Mvc;
using ProgParty.CookSousVide.Interface.Repository;
using ProgParty.CookSousVide.Models;
using System.Diagnostics;

namespace ProgParty.CookSousVide.Controllers
{
    public class HomeController : Controller
    {
        private IFoodItemRepository FoodItemRepository { get; }

        public HomeController(IFoodItemRepository foodItemRepository)
        {
            FoodItemRepository = foodItemRepository;
        }

        public IActionResult Index()
        {
            FoodItemRepository.Foo();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
