using IAgent.Application.Dtos;
using IAgent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IAgent.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agent, AgentDto>().ReverseMap();
        }
    }
}
