using System;

namespace SharesBrokeringService.Extensions
{
    public static class ShareExtensions
    {
        public static Data.Models.Share ToDataModel(this Models.Share share)
        {
            return new Data.Models.Share
            {
                AvailableShares = share.AvailableShares,
                CompanyName = share.CompanyName,
                CompanySymbol = share.CompanySymbol,
                SharePrice = share.SharePrice,
                LastUpdatedAtUTC = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ssZ")
            };
        }
    }
}
