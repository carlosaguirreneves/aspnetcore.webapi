using Xunit;

namespace AspnetCore.IntegrationTest
{
    [CollectionDefinition("TestServerStartup")]
    public class CollectionTestServerStartup : ICollectionFixture<TestServerStartup> {}
}