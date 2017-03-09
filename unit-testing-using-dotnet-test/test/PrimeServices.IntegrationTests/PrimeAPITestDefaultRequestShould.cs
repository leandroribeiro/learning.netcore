using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using PrimeService.API;
using Newtonsoft.Json;
using System.Collections.Generic;
using Prime.Domain;
using System.Linq;

namespace PrimeServices.IntegrationTests
{
    public class PrimeAPITestDefaultRequestShould : IClassFixture<TestFixture<Startup>>
    {

        private readonly HttpClient _client;

        public PrimeAPITestDefaultRequestShould(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ReturnTodoListGivenEmptyQueryString()
        {
            // Arrange 

            // Act
            var response = await _client.GetAsync("/api/service/test");

            // Assert
            response.EnsureSuccessStatusCode();

            var todoList = JsonConvert.DeserializeObject<List<Todo>>(
                    await response.Content.ReadAsStringAsync());
            var firstIdea = todoList.ElementAt(3);

            Assert.Equal("et porro tempora", firstIdea.Title);

        }

    }

}
