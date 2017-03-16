using Newtonsoft.Json;
using Prime.Domain;
using PrimeService.API;
using PrimeServices.IntegrationTests;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PrimeServices.IntegrationTests
{
    public class ApiIdeasControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public ApiIdeasControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ForSessionReturnsIdeasForValidSessionId()
        {
            // Arrange
            //var testSession = Startup.GetTestSession();

            // Act
            var response = await _client.GetAsync("/api/service/test");

            // Assert
            response.EnsureSuccessStatusCode();

            //var responseValue = await response.Content.ReadAsStringAsync();

            var todoList = JsonConvert.DeserializeObject<List<Todo>>(
                    await response.Content.ReadAsStringAsync());
            var firstIdea = todoList.First();

            Assert.Equal("delectus aut autem", firstIdea.Title);
        }
    }

}