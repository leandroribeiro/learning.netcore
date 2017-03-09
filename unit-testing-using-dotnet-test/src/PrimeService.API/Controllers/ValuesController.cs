using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prime.Domain;

namespace PrimeService.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private Prime.Domain.PrimeService _service;

        public ValuesController(Prime.Domain.PrimeService service){
            this._service = service;
        }

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

            return $"{id} should NOT be prime";
        }

    }
}
