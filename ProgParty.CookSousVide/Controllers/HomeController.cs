using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProgParty.CookSousVide.Interface.DataModel;
using ProgParty.CookSousVide.Interface.Repository;
using ProgParty.CookSousVide.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
            var model = Services.GetService<IFoodItemModel>();
            return View();
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(string animalKind, string subType)
        {
            var model = Services.GetService<IFoodItemModel>();
            model.SetKey(animalKind, subType);
            await FoodItemRepository.AddFoodItem(model);
            return View();

        }

        public async Task<JsonResult> GetAnimalKinds(string q)
        {
            var all = await FoodItemRepository.GetAnimalKindList();
            IEnumerable<string> result = all;
            if (q != "-1")
                result = all.Where(f => Compare(f, q));
            return Json(result.Select(f => new { label = f, value = f }));
        }

        public async Task<JsonResult> GetSubTypes(string animalKind, string q)
        {
            var all = (await FoodItemRepository.Get(animalKind))
                .Select(f => f.SubType)
                .Distinct();
            IEnumerable<string> result = all;
            if (q != "-1")
                result = all.Where(f => Compare(f, q));

            return Json(result.Select(f => new { value = f, data = f }));
        }

        private bool Compare(string a, string b)
            => System.Threading.Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(a, b, CompareOptions.IgnoreCase) >= 0;


        public async Task<JsonResult> GetSubTypesCount(string animalKind)
            => Json((await FoodItemRepository.GetCount(animalKind)));

        public async Task<IFoodItemModel> GetFoodItem(string animalKind, string subtype)
        {
            return await FoodItemRepository.Get(animalKind, subtype);
        }

        public async Task<IActionResult> ViewAll()
        {
            var allFoodItems = await FoodItemRepository.GetAll();
            return View(allFoodItems);
        }

        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
