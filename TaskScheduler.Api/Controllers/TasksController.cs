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
        private readonly IManager<TaskEntity> manager;
        private readonly TasksFactory<TaskEntity> tasksFactory;

        public TasksController(
            IRepository<TaskEntity> repository, 
            IManager<TaskEntity> manager,
            TasksFactory<TaskEntity> tasksFactory)
        {
            this.repository = repository;
            this.manager = manager;
            this.tasksFactory = tasksFactory;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };            
        //}

        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return null;
        //}

        [HttpPost]
        public void Post([FromBody] TaskEntity task)
        {
            repository.Add(task);
            manager.Add(task, tasksFactory.SendMessageAction);
        }

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //[Route("test")]
        //public async Task TestEndpoint()
        //{
        //    var task = new WebPingTask
        //    {
        //        Id = "3",
        //        Cron = "* * * * 1",
        //        TaskType = TaskType.WebPing,
        //        TaskOptions = new WebPingOptions
        //        {
        //            Url = "yahoo.com"
        //        }
        //    };

        //    await repository.Add(task);
        //}
    }
}
