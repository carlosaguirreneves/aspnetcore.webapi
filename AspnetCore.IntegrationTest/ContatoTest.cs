using System.Net.Http;
using System.Threading.Tasks;
using AspnetCore.WebAPI.Dtos;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace AspnetCore.IntegrationTest.API
{
    [Collection("TestServerStartup")]
    public class ContatoTest
    {
        private readonly TestServerStartup _fixture;
        private readonly ITestOutputHelper _output;

        public ContatoTest(ITestOutputHelper output, TestServerStartup fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public async Task GetContatos_Success()
        {
            var userData = new UserLoginDto {
                Login = "carlos.aguirre.neves",
                Password = "123456"
            };

            var response = await _fixture.Client.PostAsJsonAsync<UserLoginDto>("/login", userData);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var userToken = JsonConvert.DeserializeObject<UserTokenDto>(result);

            _output.WriteLine(userToken.Token);

            response.StatusCode.Should().Be(500);
        }
    }
}
