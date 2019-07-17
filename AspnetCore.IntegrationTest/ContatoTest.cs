using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspnetCore.WebAPI.Dtos;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace AspnetCore.IntegrationTest.API
{
    [Collection("TestServerStartup")]
    public class ContatoTest : IClassFixture<AuthenticationFixture>
    {
        private readonly TestServerStartup _fixture;
        private readonly ITestOutputHelper _output;
        private readonly AuthenticationFixture _auth;
        private readonly HttpClient client;

        public ContatoTest(ITestOutputHelper output, TestServerStartup fixture, AuthenticationFixture auth)
        {
            _output = output;
            _fixture = fixture;
            _auth = auth;
            
            client = fixture.Client;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _auth.Token);
        }

        [Fact]
        public async Task GetAllContatos_StatusCode_OK_And_NotEmpty()
        {
            var response = await client.GetAsync("/contato?size=10&page=1");
            var result = await response.Content.ReadAsStringAsync();
            _output.WriteLine(result);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(200);

            var contatos = JsonConvert.DeserializeObject<List<ContatoDto>>(result);
            Assert.NotEmpty(contatos);
        }
    }
}
