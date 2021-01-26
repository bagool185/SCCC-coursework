using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SharesBrokeringService;
using SharesBrokeringService.Commands;
using SharesBrokeringService.Queries;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SharesBrokeringService
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(s => new CosmosClientBuilder(EnvironmentVariables.CosmosDBConnectionString).Build());
            builder.Services.AddSingleton<UpdateShareCommand>();
            builder.Services.AddSingleton<GetShareQuery>();
        }
    }
}
