using Microsoft.AspNetCore.Mvc;
using ProgParty.CookSousVide.Interface.Repository;
using System;

namespace ProgParty.CookSousVide.Controllers
{
    public class FoodItemController : Controller
    {
        private IFoodItemRepository FoodItemRepository { get; }
        private IServiceProvider Services { get; }

        public FoodItemController(IFoodItemRepository foodItemRepository, IServiceProvider services)
        {
            FoodItemRepository = foodItemRepository;
            Services = services;
        }

        public IActionResult Show()
        {
            //string animalKind, string subType
            return View();
            //throw new NotImplementedException();
        }
    }
}
