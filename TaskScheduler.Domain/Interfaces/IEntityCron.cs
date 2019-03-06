using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Domain.Interfaces
{
    public interface IEntityCron
    {
        string Cron { get; set; }
    }
}
