using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public class SavePageTask : BaseTask
    {
        public SavePageOptions TaskOptions { get; set; }
    }
}
