using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Api
{
    public class TasksFactory<T>
    {
        private readonly IQueueWriter<T> queueWriter;

        public TasksFactory(IQueueWriter<T> queueWriter)
        {
            this.queueWriter = queueWriter;
        }

        public Task SendMessageAction(T message) => queueWriter.Send(message);
    }
}
