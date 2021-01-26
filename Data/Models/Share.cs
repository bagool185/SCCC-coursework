using Newtonsoft.Json;
using SharesBrokeringService.Models;

namespace SharesBrokeringService.Data.Models
{
    public class Share
    {
        [JsonProperty("id")]
        public string ID => CompanySymbol;

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companySymbol")]
        public string CompanySymbol { get; set; }

        [JsonProperty("availableShares")]
        public int AvailableShares { get; set; }

        [JsonProperty("sharePrice")]
        public SharePrice SharePrice { get; set; }

        [JsonProperty("lastUpdatedAtUTC")]
        public string LastUpdatedAtUTC { get; set; }

        [JsonProperty("/companyName")]
        public string PartitionKey => CompanySymbol;
    }
}
