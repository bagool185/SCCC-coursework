using Newtonsoft.Json;

namespace SharesBrokeringService.Models
{
    public class SharePrice
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Share
    {
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        
        [JsonProperty("companySymbol")]
        public string CompanySymbol { get; set; }
        
        [JsonProperty("availableShares")]
        public int AvailableShares { get; set; }
        
        [JsonProperty("sharePrice")]
        public SharePrice SharePrice { get; set; }
    }
}
