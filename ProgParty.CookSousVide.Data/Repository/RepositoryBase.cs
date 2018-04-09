using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ProgParty.CookSousVide.Data.Repository
{
    public abstract class RepositoryBase
    {
        protected abstract string TableName { get; }
        private IConfiguration Configuration { get; }

        public RepositoryBase(IConfiguration configuation)
        {
            Configuration = configuation;
        }

        protected CloudTable GetTable()
        {
            var connectionString = Configuration.GetConnectionString("AzureTableStorage");
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(TableName);
            return table;
        }
    }
}
