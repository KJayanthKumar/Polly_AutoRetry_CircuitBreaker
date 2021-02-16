using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return GetValues();
        }

        private string[] GetValues()
        {
            var httpClient = httpClientFactory.CreateClient("errorApiClient");

            var response = httpClient.GetAsync("api/values").Result;
            return JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
