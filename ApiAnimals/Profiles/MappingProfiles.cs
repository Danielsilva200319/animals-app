using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Entities;
using Core.Entities;

namespace ApiAnimals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Ciudad,CiudadDto>().ReverseMap();
            CreateMap<Cliente,ClienteDto>().ReverseMap();
            CreateMap<Raza,RazaDto>().ReverseMap();
            CreateMap<Cita,CitaDto>().ReverseMap();

        }
    }
}