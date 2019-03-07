﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public class WebPingTask : BaseTask
    {
        public WebPingOptions TaskOptions { get; set; }
    }
}
