using Microsoft.Extensions.Configuration;

namespace AlzaProduct.Persistent.EF.IntegrationTests
{
    internal static class TestDatabaseConfig
    {
        private static readonly IConfigurationRoot _configuration = LoadConfiguration();

        private static IConfigurationRoot LoadConfiguration()
        {
            var basePath = Directory.GetCurrentDirectory();

            var configFilePath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found at: {configFilePath}");
            }

            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static string GetTestConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("TestDatabaseConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Test database connection string is not configured.");
            }

            return connectionString;
        }
    }
}
