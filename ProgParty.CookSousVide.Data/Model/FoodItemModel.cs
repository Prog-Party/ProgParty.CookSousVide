using Microsoft.WindowsAzure.Storage.Table;

namespace ProgParty.CookSousVide.Data.Model
{
    public class FoodItemModel : TableEntity
    {
        public string AnimalKind => PartitionKey;
        public string SubType => RowKey;

        public double TemperatureRare { get; set; }
        public double TemperatureWellDone { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public FoodItemModel(string animalKind, string subType) : base(animalKind, subType)
        {
        }
    }
}
