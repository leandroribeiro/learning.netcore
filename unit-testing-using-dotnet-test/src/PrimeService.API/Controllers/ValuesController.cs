using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prime.Services;

namespace PrimeService.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private Prime.Services.PrimeService _service;

        public ValuesController()
        {
            this._service = new Prime.Services.PrimeService();
        }

        /*
                public ValuesController(Prime.Services.PrimeService service){
                    this._service = service;
                }
        */

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (_service.IsPrime(id))
                return $"{id} should be prime";

            return $"{id} should not be prime";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
