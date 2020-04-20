using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using Xunit;

namespace TechnicalChallenge.API2.IntegrationTest
{
    public class ShowMeTheCodeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public ShowMeTheCodeControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void ShowMeTheCodeController_GET()
        {
            var client = _factory.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/showmethecode");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();

            result.Should().Be("https://github.com/Takeshi-Gerent/TechnicalChallenge");
        }
    }
    
    
}
