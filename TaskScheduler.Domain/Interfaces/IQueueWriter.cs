using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Domain.Interfaces
{
    public interface IQueueWriter<T>
    {
        Task Send(T entity);
    }
}
