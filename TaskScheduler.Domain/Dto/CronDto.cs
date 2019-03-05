using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Domain.Dto
{
    public class CronDto
    {
        public string Minute { get; set; }

        public string Hour { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string WeekDay { get; set; }
    }
}
