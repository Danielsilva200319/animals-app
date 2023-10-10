using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Entities;

namespace ApiAnimals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Ciudad,CiudadDto>().ReverseMap();
        }
    }
}