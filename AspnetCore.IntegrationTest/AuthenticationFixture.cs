using System.Net.Http;
using System.Net.Http.Headers;
using AspnetCore.IntegrationTest;
using AspnetCore.WebAPI.Dtos;
using Newtonsoft.Json;

public class AuthenticationFixture 
{
    private readonly TestServerStartup _fixture;
    public string Token;
    
    public AuthenticationFixture(TestServerStartup fixture)
    {
        _fixture = fixture;

         Token = GetUserToken();
    }

    private string GetUserToken() {
        var userData = new UserLoginDto {
            Login = "carlos.aguirre.neves",
            Password = "123456"
        };

        var content = new StringContent(JsonConvert.SerializeObject(userData));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = _fixture.Client.PostAsync("/login", content).Result;

        var result = response.Content.ReadAsStringAsync().Result;
        var userToken = JsonConvert.DeserializeObject<UserTokenDto>(result);

        return userToken.Token;
    }
}