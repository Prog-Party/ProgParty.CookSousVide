using Microsoft.WindowsAzure.Storage.Table;
using ProgParty.CookSousVide.Interface.DataModel;

namespace ProgParty.CookSousVide.Data.Model
{
    public class FoodItemModel : TableEntity, IFoodItemModel
    {
        public string AnimalKind => PartitionKey;
        public string SubType => RowKey;

        public double TemperatureRare { get; set; }
        public double TemperatureWellDone { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public FoodItemModel() { }
        public FoodItemModel(string animalKind, string subType) : base(animalKind, subType)
        {
        }

        public void SetKey(string animalKind, string subType)
        {
            PartitionKey = animalKind;
            RowKey = subType;
        }
    }
}
