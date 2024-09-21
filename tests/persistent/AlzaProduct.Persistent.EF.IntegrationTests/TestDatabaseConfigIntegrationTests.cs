using Xunit;

namespace AlzaProduct.Persistent.EF.IntegrationTests;
public class TestDatabaseConfigIntegrationTests
{
    [Fact]
    public void GetTestConnectionString_ShouldReturnValidConnectionString()
    {
        var connectionString = TestDatabaseConfig.GetTestConnectionString();

        Assert.False(string.IsNullOrEmpty(connectionString), "Test Db Connection string should not be null or empty");

        Assert.Contains("Test", connectionString);
    }
}
