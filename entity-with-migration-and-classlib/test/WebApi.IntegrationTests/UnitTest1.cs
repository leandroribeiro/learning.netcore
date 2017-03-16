using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using aspnetcore_lab2.webapi;

namespace WebApi.IntegrationTests 
{
    public class UnitTest1 : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public UnitTest1(TestFixture<Startup> fixture)
        {
            // Arrange
            _client = fixture.Client;
        }

        [Fact]
        public async void Test1()
        {
            // Act
            var response = await _client.GetAsync("/api/values");

            // Assert
            response.EnsureSuccessStatusCode();

            var values = JsonConvert.DeserializeObject<IEnumerable<String>>(await response.Content.ReadAsStringAsync()).ToList();

            Assert.Equal(2, values.Count);
        }
    }
}
