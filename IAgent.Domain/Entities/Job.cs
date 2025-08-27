using IAgent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public JobType Type { get; set; }
        public List<TaskType>? SubTaskTypes { get; set; } = new();
    }
}
