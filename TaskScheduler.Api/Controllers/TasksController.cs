using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskScheduler.DAL;
using TaskScheduler.Domain;
using TaskScheduler.Domain.Dto;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;

namespace TaskScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<TaskEntity> repository;
        private readonly IQueueWriter<TaskEntity> queueWriter;

        public TasksController(IRepository<TaskEntity> repository, IQueueWriter<TaskEntity> queueWriter)
        {
            this.repository = repository;
            this.queueWriter = queueWriter;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<string> Get()
        {
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

        [Route("test")]
        public async Task TestEndpoint()
        {
            var task = new WebPingTask
            {
                Id = "3",
                Cron = "* * * * 1",
                TaskType = TaskType.WebPing,
                TaskOptions = new WebPingOptions
                {
                    Url = "yahoo.com"
                }
            };

            await repository.Add(task);


        }
    }
}
