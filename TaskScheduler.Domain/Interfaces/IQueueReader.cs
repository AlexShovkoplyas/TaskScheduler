using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Domain.Interfaces
{
    public interface IQueueReader
    {
        Task<string> Read();
    }
}
