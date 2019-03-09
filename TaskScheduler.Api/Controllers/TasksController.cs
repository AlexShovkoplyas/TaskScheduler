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
        private readonly IRepository<BaseTask> repository;
        private readonly IManager<BaseTask> manager;
        private readonly TasksFactory<BaseTask> tasksFactory;

        public TasksController(
            IRepository<BaseTask> repository, 
            IManager<BaseTask> manager,
            TasksFactory<BaseTask> tasksFactory)
        {
            this.repository = repository;
            this.manager = manager;
            this.tasksFactory = tasksFactory;
        }

        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<BaseTask>> List()
        {
            return await repository.List();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<BaseTask> Get(string id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public async void Post([FromBody] BaseTask task)
        {
            await repository.Add(task);
            manager.Add(task, tasksFactory.SendMessageAction);
        }

        [HttpPut]
        public async void Put([FromBody] BaseTask task)
        {
            await repository.Update(task);
            manager.Remove(task.Id);
            manager.Add(task, tasksFactory.SendMessageAction);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await repository.Remove(id);
            manager.Remove(id);
        }

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
