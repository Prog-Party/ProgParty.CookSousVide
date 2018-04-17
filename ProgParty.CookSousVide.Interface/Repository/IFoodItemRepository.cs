using ProgParty.CookSousVide.Interface.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgParty.CookSousVide.Interface.Repository
{
    public interface IFoodItemRepository
    {
        Task AddFoodItem(IFoodItemModel foodItem);
        Task<List<IFoodItemModel>> Get();
        Task<List<IFoodItemModel>> Get(string animalKind);
        Task<IFoodItemModel> Get(string animalKind, string subType);
        Task<int> GetCount(string animalKind);
    }
}
