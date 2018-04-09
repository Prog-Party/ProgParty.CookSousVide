using Microsoft.WindowsAzure.Storage.Table;

namespace ProgParty.CookSousVide.Interface.DataModel
{
    public interface IFoodItemModel : ITableEntity
    {
        string AnimalKind { get; }
        string SubType { get; }

        double TemperatureRare { get; set; }
        double TemperatureWellDone { get; set; }

        int CookingTimeInMinutes { get; set; }

        void SetKey(string animalKind, string subType);
    }
}
