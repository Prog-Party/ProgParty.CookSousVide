using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProgParty.CookSousVide.Interface.DataModel;
using ProgParty.CookSousVide.Interface.Repository;
using ProgParty.CookSousVide.Models;
using System;
using System.Diagnostics;

namespace ProgParty.CookSousVide.Controllers
{
    public class HomeController : Controller
    {
        private IFoodItemRepository FoodItemRepository { get; }
        private IServiceProvider Services { get; }

        public HomeController(IFoodItemRepository foodItemRepository, IServiceProvider services)
        {
            FoodItemRepository = foodItemRepository;
            Services = services;
        }

        public IActionResult Index()
        {
            var model = Services.GetService<IFoodItemModel>();// "abc", "def");
            model.SetKey("abc", "def");
            FoodItemRepository.AddFoodItem(model);
            return View();
        }

        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
