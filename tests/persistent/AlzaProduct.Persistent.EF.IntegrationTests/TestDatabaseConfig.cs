using Microsoft.Extensions.Configuration;

namespace AlzaProduct.Persistent.EF.IntegrationTests;
internal static class TestDatabaseConfig
{
    private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())
        !.Parent!.Parent!.Parent!.Parent!.Parent!.FullName + @"\src\AlzaProduct.Api")
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    public static string GetTestConnectionString()
    {
        return _configuration.GetConnectionString("TestDatabaseConnection")!;
    }
}
