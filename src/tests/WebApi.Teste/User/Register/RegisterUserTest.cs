using FluentAssertions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using UtilidadesComunsTestes.Requests;

namespace WebApi.Teste.User.Register
{

    public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private readonly string method = "user";
        public RegisterUserTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
          
            var response = await _httpClient.PostAsJsonAsync(method, request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var respondeData = await JsonDocument.ParseAsync(responseBody);

            respondeData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);

        }
    }
}