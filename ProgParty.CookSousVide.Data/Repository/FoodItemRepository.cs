using Microsoft.Extensions.Configuration;
using ProgParty.CookSousVide.Interface.Repository;

namespace ProgParty.CookSousVide.Data.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private IConfiguration Configuration { get; }

        public FoodItemRepository(IConfiguration configuation)
        {
            Configuration = configuation;
        }

        public void Foo() {
            var v = Configuration.GetConnectionString("AzuerTableStorage");
        }
    }
}
