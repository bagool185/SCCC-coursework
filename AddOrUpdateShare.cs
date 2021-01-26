using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using SharesBrokeringService.Commands;
using SharesBrokeringService.Extensions;
using System.IO;
using System.Threading.Tasks;

namespace SharesBrokeringService
{
    public class AddOrUpdateShare
    {
        private readonly UpdateShareCommand _updateShareCommand;

        public AddOrUpdateShare(UpdateShareCommand updateShareCommand)
        {
            _updateShareCommand = updateShareCommand;
        }

        [FunctionName("AddOrUpdateShare")]
        public async Task<ObjectResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, Route = "company-symbol")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();

            var share = JsonConvert.DeserializeObject<Models.Share>(body);

            await _updateShareCommand.ExecuteAsync(share.ToDataModel());

            return new OkObjectResult(share);
        }
    }
}
