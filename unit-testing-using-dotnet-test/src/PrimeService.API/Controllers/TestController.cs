
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace PrimeService.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public TestController()
        {
        }

        // GET api/vendor
        [HttpGet]
        public async Task<string> Get()
        {
            var baseAddress = "https://www.something.com.br/api/someone";

            // Retrieve the user's To Do List.
            //
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);


            var authByteArray = Encoding.ASCII.GetBytes("username:password");
            var authString = Convert.ToBase64String(authByteArray);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authString);

            HttpResponseMessage response = await client.SendAsync(request);

            //
            // Return the To Do List in the view.
            //
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