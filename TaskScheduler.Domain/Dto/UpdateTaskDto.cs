using System;

namespace TaskScheduler.Domain.Dto
{
    public class UpdateTaskDto : CreateTaskDto
    {
        public int Id { get; set; }
    }
}
