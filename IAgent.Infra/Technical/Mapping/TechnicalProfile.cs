using AutoMapper;
using IAgent.Application.Dtos;
using IAgent.Infra.Outbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Mapping
{
    public class TechnicalProfile : Profile
    {
        public TechnicalProfile()
        {
            CreateMap<OutboxMessageDto, OutboxMessage>().ReverseMap();
        }
    }
}
