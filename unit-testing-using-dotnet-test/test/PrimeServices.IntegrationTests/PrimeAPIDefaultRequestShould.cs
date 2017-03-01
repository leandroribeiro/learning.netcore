using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace PrimeServices.IntegrationTests
{
    public class PrimeAPIDefaultRequestShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public PrimeAPIDefaultRequestShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<PrimeService.API.Startup>());
            _client = _server.CreateClient();
        }

    private async Task<string> GetCheckPrimeResponseString(
        string querystring = "")
    {
        var request = "/api/values";
        if(!string.IsNullOrEmpty(querystring))
        {
            request += "?" + querystring;
        }
        var response = await _client.GetAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

        [Fact]
        public async Task ReturnValuesGivenEmptyQueryString()
        {
            // Act
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[\"value1\",\"value2\"]", responseString);
        }

        [Theory] 
        [InlineData(4)] 
        [InlineData(6)] 
        [InlineData(8)] 
        [InlineData(9)] 
        public async Task ReturnPrimeGiveNonPrimesLessThan10(int value)
        {
            // Act
            var response = await _client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal($"{value} should not be prime", responseString);
        }

        [Theory] 
        [InlineData(2)] 
        [InlineData(3)] 
        [InlineData(5)] 
        [InlineData(7)] 
        public async Task ReturnPrimeGivePrimesLessThan10(int value)
        {
            // Act
            var response = await _client.GetAsync($"/api/values/{value}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal($"{value} should be prime", responseString);
        }

    }

}
