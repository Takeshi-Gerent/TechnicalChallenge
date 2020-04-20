using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace TechnicalChallenge.API1.IntegrationTest
{
    public class TaxaJurosControllerTest: IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public TaxaJurosControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;            
        }

        [Fact]                
        public async void TaxaJurosController_GET()
        {
            var client = _factory.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod("GET"), "/taxajuros");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
    }
}
