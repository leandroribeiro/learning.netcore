using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace Prime.Services
{
    public class TodoService
    {
        private readonly IOptions<Prime.Entities.TODOSettings> _serviceSettings;

        public TodoService(IOptions<Prime.Entities.TODOSettings> serviceSettings){
            _serviceSettings = serviceSettings;
        }
        public async Task<string> GetAll()
        {
            var baseAddress = _serviceSettings.Value.BaseAddress;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);

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

        public async Task<string> GetAll(string username, string password)
        {
            var baseAddress = _serviceSettings.Value.BaseAddress;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);

            var authByteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
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

    }
}