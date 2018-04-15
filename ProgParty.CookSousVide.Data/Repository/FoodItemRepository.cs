using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using ProgParty.CookSousVide.Data.Extention;
using ProgParty.CookSousVide.Data.Model;
using ProgParty.CookSousVide.Interface.DataModel;
using ProgParty.CookSousVide.Interface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgParty.CookSousVide.Data.Repository
{
    public class FoodItemRepository : RepositoryBase, IFoodItemRepository
    {
        protected override string TableName => "FoodItem";

        public FoodItemRepository(IConfiguration configuation) : base(configuation) { }
        
        public async Task AddFoodItem(IFoodItemModel foodItem)
        {
            var table = GetTable();
            var insertOperation = TableOperation.Insert(foodItem);
            await table.ExecuteAsync(insertOperation);
        }
        public async Task<List<IFoodItemModel>> Get()
        {
            var table = GetTable();
            var foodItems = await table.ExecuteQuery(new TableQuery<FoodItemModel>());
            return foodItems.ToList<IFoodItemModel>();
        }
        public async Task<List<IFoodItemModel>> Get(string animalKind)
        {
            var table = GetTable();
            var foodItems = await table.ExecuteQuery(new TableQuery<FoodItemModel>() { FilterString = GetPartitionKeyCondition(animalKind) });
            return foodItems.ToList<IFoodItemModel>();
        }

        public static string GetPartitionKeyCondition(string partitionKey) 
            => TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);

    }
}
