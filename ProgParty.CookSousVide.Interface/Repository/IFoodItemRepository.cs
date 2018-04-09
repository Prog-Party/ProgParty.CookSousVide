using ProgParty.CookSousVide.Interface.DataModel;
using System.Threading.Tasks;

namespace ProgParty.CookSousVide.Interface.Repository
{
    public interface IFoodItemRepository
    {
        Task AddFoodItem(IFoodItemModel foodItem);
    }
}
