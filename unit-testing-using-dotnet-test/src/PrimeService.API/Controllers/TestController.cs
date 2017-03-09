
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PrimeService.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        IOptions<Prime.Entities.TODOSettings> _configuration;
        private Prime.Domain.TodoService _service;

        public TestController(IOptions<Prime.Entities.TODOSettings> configuration, Prime.Domain.TodoService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpGet("~/api/local/test")]
        public async Task<string> GetDataExternalAPI()
        {
            //var baseAddress = "https://jsonplaceholder.typicode.com/todos";
            var baseAddress = _configuration.Value.BaseAddress;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                List<Dictionary<String, String>> responseElements = new List<Dictionary<String, String>>();
                //JsonSerializerSettings settings = new JsonSerializerSettings();
                String responseString = await response.Content.ReadAsStringAsync();

                /*responseElements = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(responseString, settings);
                foreach (Dictionary<String, String> responseElement in responseElements)
                {
                    TodoItem newItem = new TodoItem();
                    newItem.Title = responseElement["title"];
                    newItem.Owner = responseElement["owner"];
                    itemList.Add(newItem);
                }

                return View(itemList);*/

                return responseString;
            }
            else
                return "error";

        }

        [HttpPost("~/api/local/test")]
        public async Task<string> GetDataExternalAPIAuth()
        {
            var baseAddress = "https://jsonplaceholder.typicode.com/todos";

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);


            var authByteArray = Encoding.ASCII.GetBytes("username:password");
            var authString = Convert.ToBase64String(authByteArray);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authString);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                List<Dictionary<String, String>> responseElements = new List<Dictionary<String, String>>();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                String responseString = await response.Content.ReadAsStringAsync();

                /*responseElements = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(responseString, settings);
                foreach (Dictionary<String, String> responseElement in responseElements)
                {
                    TodoItem newItem = new TodoItem();
                    newItem.Title = responseElement["title"];
                    newItem.Owner = responseElement["owner"];
                    itemList.Add(newItem);
                }

                return View(itemList);*/

                return responseString;
            }
            else
                return "error";

        }

        [HttpGet("~/api/service/test")]
        public async Task<string> GetDataServiceAPI()
        {
            return await _service.GetAll();
        }
    }
}