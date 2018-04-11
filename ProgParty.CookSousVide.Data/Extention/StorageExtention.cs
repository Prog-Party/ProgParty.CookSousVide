using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgParty.CookSousVide.Data.Extention
{
    public static class StorageExtention
    {
        public static async Task<List<T>> ExecuteQuery<T>(this CloudTable table, TableQuery<T> query) where T : ITableEntity, new()
        {
            var result = new List<T>();
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                result.AddRange(resultSegment.Results);
            } while (token != null);

            return result;
        }
    }
}
