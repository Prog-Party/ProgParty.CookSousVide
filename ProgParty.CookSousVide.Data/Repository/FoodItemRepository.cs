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

        private async Task SetAnimalKindList()
        {
            var allAnimalKinds = new AllAnimalKinds();
            allAnimalKinds.SetAll(await GetAllAnimalKinds());

            var table = GetTable();
            await table.ExecuteAsync(TableOperation.InsertOrReplace(allAnimalKinds));
        }

        private async Task<List<string>> GetAllAnimalKinds()
            => (await GetAll())
                .Select(f => f.AnimalKind)
                .Distinct()
                .Where(s => s != "All")
                .ToList();

        public async Task<List<string>> GetAnimalKindList()
        {
            var table = GetTable();
            var allAnimalKinds = (await table.ExecuteAsync(TableOperation.Retrieve<AllAnimalKinds>("All", "All")));
            return ((AllAnimalKinds)allAnimalKinds.Result).GetAll();
        }

        public async Task AddFoodItem(IFoodItemModel foodItem)
        {
            var table = GetTable();
            var insertOperation = TableOperation.Insert(foodItem);
            await table.ExecuteAsync(insertOperation);
            await SetAnimalKindList();
        }
        public async Task<List<IFoodItemModel>> GetAll()
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

        public async Task<IFoodItemModel> Get(string animalKind, string subType)
        {
            var filterRow = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, subType);

            var table = GetTable();
            var foodItems = await table.ExecuteQuery(new TableQuery<FoodItemModel>().Where(filterRow));
            return foodItems.SingleOrDefault();
        }

        public async Task<int> GetCount(string animalKind)
        {
            var table = GetTable();
            var foodItems = await table.ExecuteQuery(new TableQuery<TableEntity>() { FilterString = GetPartitionKeyCondition(animalKind) });
            return foodItems.Count();
        }

        public static string GetPartitionKeyCondition(string partitionKey)
            => TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);
    }
}
