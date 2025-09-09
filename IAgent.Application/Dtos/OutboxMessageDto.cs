using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Dtos
{
    public class OutboxMessageDto
    {
        public OutboxMessageDto() { }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}
