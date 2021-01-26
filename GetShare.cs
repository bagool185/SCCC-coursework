using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using SharesBrokeringService.Queries;
using System.Threading.Tasks;

namespace SharesBrokeringService
{
    public class GetShare
    {
        private readonly GetShareQuery _getShareQuery;

        public GetShare(GetShareQuery getShareQuery)
        {
            _getShareQuery = getShareQuery;
        }

        [FunctionName("GetShare")]
        public async Task<ObjectResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, Route = "company-symbol/{companySymbol}")] HttpRequest req, string companySymbol)
        {
            var share = await _getShareQuery.ExecuteAsync(companySymbol);

            return new OkObjectResult(share);
        }
    }
}
