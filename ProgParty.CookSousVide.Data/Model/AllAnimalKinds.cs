using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;

namespace ProgParty.CookSousVide.Data.Model
{
    internal class AllAnimalKinds : TableEntity
    {
        public string All { get; set; }
        public List<string> GetAll()
            => All.Split('|').ToList();

        public AllAnimalKinds() : base("All", "All") { }

        internal void SetAll(List<string> all)
        {
            All = string.Join('|', all);
        }
    }
}
