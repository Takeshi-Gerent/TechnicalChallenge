using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TechnicalChallenge.API2.Config;
using Unity;
using Xunit;

namespace TechnicalChallenge.API2.IntegrationTest
{
    public class CalculaJurosControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public static IEnumerable<object[]> GetParametersFor_GET()
        {
            yield return new object[] { 100M, 5, "105,10", "0,01"};
            yield return new object[] { 100M, 2, "104,04", "0,02" };
        }

        private readonly WebApplicationFactory<Startup> _factory;

        public CalculaJurosControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(GetParametersFor_GET))]
        public async void CalculaJurosController_GET(decimal initialValue, int time, string expectedResult, string interestRate)
        {
            //Arrange
            Environment.SetEnvironmentVariable("API1_URL", "localhost:5020");
            var container = UnityConfig.GetConfiguredContainer();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(interestRate),
                });

            var api1client = new HttpClient(mockHttpMessageHandler.Object);
            api1client.BaseAddress = new Uri("http://any:123");            

            container.RegisterFactory<HttpClient>("api1", factory => api1client);

            var client = _factory.WithWebHostBuilder(hostbuilder =>
            {
                hostbuilder.ConfigureTestServices((services) => {
                    services.AddSingleton<IUnityContainer>(container);
                });
            }).CreateClient();
           
            //Act
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/calculajuros?valorInicial={initialValue}&meses={time}");

            var response = await client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var result = await response.Content.ReadAsStringAsync();

            result.Should().Be(expectedResult);
        }
    }
}
