using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ApiAnimals.Controllers
{
    public class CiudadController
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public CiudadController(UnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CiudadDto>(ciudad);
        }
        private ActionResult<CiudadDto> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}