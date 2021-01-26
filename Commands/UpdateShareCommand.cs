using Microsoft.Azure.Cosmos;
using SharesBrokeringService.Extensions;
using System;
using System.Net;
using System.Threading.Tasks;
using Share = SharesBrokeringService.Data.Models.Share;

namespace SharesBrokeringService.Commands
{
    public interface IUpdateShareCommand
    {
        Task ExecuteAsync(Share share);
    }

    public class UpdateShareCommand : IUpdateShareCommand
    {
        private readonly Container _sharesContainer;

        public UpdateShareCommand(CosmosClient cosmosClient)
        {
            _sharesContainer = cosmosClient.GetSharesContainer();
        }

        public async Task ExecuteAsync(Share share)
        {
            try
            {
                await _sharesContainer.UpsertItemAsync(share, new PartitionKey(share.PartitionKey));
            }
            catch (CosmosException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("it's an upsert why tf do you throw a 404 cosmos");
            }
        }
    }
}
