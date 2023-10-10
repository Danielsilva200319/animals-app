using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class RazaController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
        {
            var razas = await _unitOfWork.Razas.GetAllAsync();
            return _mapper.Map<List<RazaDto>>(razas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RazaDto>> Get(int id)
        {
            var razas = await _unitOfWork.Razas.GetByIdAsync(id);
            if (razas == null)
            {
                return NotFound();
            }
            return _mapper.Map<RazaDto>(razas);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Raza>> Post(RazaDto razaDto)
        {
            var raza = _mapper.Map<Raza>(razaDto);
            this._unitOfWork.Razas.Add(raza);
            await _unitOfWork.SaveAsync();
            if (raza == null)
            {
                return BadRequest();
            }
            razaDto.Id = raza.Id;
            return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto razaDto)
        {
            var razas = _mapper.Map<Raza>(razaDto);
            if (razaDto == null)
            {
                return NotFound();
            }
            if(razas.Id == 0)
            {
                razas.Id = id;
            }
            if(razas.Id != id)
            {
                return BadRequest();
            }
            razaDto.Id = razas.Id;
            _unitOfWork.Razas.Update(razas);
            await _unitOfWork.SaveAsync();
            return razaDto;
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Raza>> Delete(int id)
        {
            var raza = await _unitOfWork.Razas.GetByIdAsync(id);
            if (raza == null)
            {
                return NotFound();
            }
            _unitOfWork.Razas.Remove(raza);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}