using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataInspector.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DataInspector.API.Controllers
{
    [Route("api/default")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IConfiguration configuration;

        public DefaultController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/Default
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Stephen's demo",
                "DataInspector API",
                configuration.GetConnectionString("Default"),
                configuration.GetValue<string>("AllowedOrigins")
            };
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
