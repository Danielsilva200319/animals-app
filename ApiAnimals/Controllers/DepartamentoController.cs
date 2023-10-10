using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class DepartamentoController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var departamentos = await _unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(departamentos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return _mapper.Map<DepartamentoDto>(departamento);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto departamentoDto)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDto);
            this._unitOfWork.Departamentos.Add(departamento);
            await _unitOfWork.SaveAsync();
            if (departamento == null)
            {
                return BadRequest();
            }
            departamentoDto.Id = departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = departamentoDto.Id }, departamentoDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto departamentoDto)
        {
            var departamentos = _mapper.Map<Departamento>(departamentoDto);
            if (departamentos == null)
            {
                return NotFound();
            }
            if (departamentos.Id == 0)
            {
                departamentos.Id = id;
            }
            if (departamentos.Id != id)
            {
                return BadRequest();
            }
            departamentoDto.Id = departamentos.Id;
            _unitOfWork.Departamentos.Update(departamentos);
            await _unitOfWork.SaveAsync();
            return departamentoDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            _unitOfWork.Departamentos.Remove(departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}