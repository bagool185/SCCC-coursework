using System;

namespace SharesBrokeringService
{
    public static class EnvironmentVariables
    {
        public static string CosmosDBConnectionString => Environment.GetEnvironmentVariable("CosmosDBConnectionString");
        public static string SharesDB => Environment.GetEnvironmentVariable("SharesDB");
        public static string SharesContainer => Environment.GetEnvironmentVariable("SharesContainer");
    }
}
