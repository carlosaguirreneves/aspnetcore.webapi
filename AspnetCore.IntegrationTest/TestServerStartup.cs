using System;
using System.IO;
using System.Net.Http;
using AspnetCore.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace AspnetCore.IntegrationTest
{
    public class TestServerStartup : IDisposable
    {
        public HttpClient Client { get; set; }

        public TestServerStartup()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            var integrationTestsPath = Environment.CurrentDirectory;
            var applicationPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../../../AspnetCore.WebAPI/appsettings.Testing.json"));
 
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(applicationPath, optional: false, reloadOnChange: true);
            var config = configurationBuilder.Build();
    
            var server = new TestServer(new WebHostBuilder()
                            .UseConfiguration(config)
                            .UseKestrel()
                            .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}