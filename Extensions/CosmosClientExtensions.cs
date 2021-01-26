using Microsoft.Azure.Cosmos;

namespace SharesBrokeringService.Extensions
{
    public static class CosmosClientExtensions
    {
        public static Container GetSharesContainer(this CosmosClient cosmosClient) => cosmosClient.GetContainer(EnvironmentVariables.SharesDB, EnvironmentVariables.SharesContainer);
    }
}
