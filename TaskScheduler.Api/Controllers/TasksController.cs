using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskScheduler.DAL;
using TaskScheduler.Domain;
using TaskScheduler.Domain.Dto;

namespace TaskScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TestDbAccess db = new TestDbAccess();

        // GET: api/Tasks
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await db.Method();
            return new string[] { "value1", "value2" };
            
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tasks
        [HttpPost]
        public void Post([FromBody] CreateTaskDto task)
        {

        }

        // PUT: api/Tasks/5
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
