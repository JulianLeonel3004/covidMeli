using AutoMapper;
using Model.MasterModel;
using Model.People;
using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiler
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Dna, DnaDTO>();
            CreateMap<Result, ResultDTO>();
        }
    }
}
