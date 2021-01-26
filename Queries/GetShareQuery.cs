using Microsoft.Azure.Cosmos;
using SharesBrokeringService.Extensions;
using System.Threading.Tasks;
using Share = SharesBrokeringService.Data.Models.Share;

namespace SharesBrokeringService.Queries
{
    public interface IGetShareQuery
    {
        Task<Share> ExecuteAsync(string companySymbol);
    }

    public class GetShareQuery : IGetShareQuery
    {
        private readonly Container _sharesContainer;

        public GetShareQuery(CosmosClient cosmosClient)
        {
            _sharesContainer = cosmosClient.GetSharesContainer();
        }

        public async Task<Share> ExecuteAsync(string companySymbol)
        {
            var query = "SELECT * FROM c WHERE c.companySymbol=@companySymbol";
            var queryDefinition = new QueryDefinition(query).WithParameter("companySymbol", companySymbol);

            var iterator = _sharesContainer.GetItemQueryIterator<Share>(queryDefinition);

            if (iterator.HasMoreResults)
            {
                var result = await iterator.ReadNextAsync();

                return result.Resource as Share;
            }

            return null;
        }
    }
}
