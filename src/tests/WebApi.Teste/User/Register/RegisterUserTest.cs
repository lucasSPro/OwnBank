using FluentAssertions;
using GestorAvaliacao.Exceptions;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using UtilidadesComunsTestes.Requests;
using WebApi.Teste.InlineData;

namespace WebApi.Teste.User.Register
{

    public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private readonly string METHOD = "user";
        public RegisterUserTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
          
            var response = await _httpClient.PostAsJsonAsync(METHOD, request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var respondeData = await JsonDocument.ParseAsync(responseBody);

            respondeData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_Name(string culture)
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync(METHOD, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

            var expectedMessage = ResourceMessagesException.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

            errors.Should().ContainSingle().And.Contain(error => error.GetString()!.Equals(expectedMessage));
        }
    }
}