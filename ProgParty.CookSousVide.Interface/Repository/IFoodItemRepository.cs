using ProgParty.CookSousVide.Interface.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgParty.CookSousVide.Interface.Repository
{
    public interface IFoodItemRepository
    {
        Task AddFoodItem(IFoodItemModel foodItem);
        /// <summary>
        /// This is a very slow operation, be very carefull with using
        /// </summary>
        /// <returns></returns>
        Task<List<IFoodItemModel>> GetAll();
        Task<List<IFoodItemModel>> Get(string animalKind);
        Task<IFoodItemModel> Get(string animalKind, string subType);
        Task<int> GetCount(string animalKind);
        Task<List<string>> GetAnimalKindList();
    }
}
