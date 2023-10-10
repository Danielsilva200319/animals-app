using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using core.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class ClienteController : BaseControllerApi
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ClienteController(UnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var clientes = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(clientes);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteDto>(cliente);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            this._unitOfWork.Clientes.Add(cliente);
            await _unitOfWork.SaveAsync();
            if (cliente == null)
            {
                return BadRequest();
            }
            clienteDto.Id = cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return NotFound();
            }
            var clientes = _mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Update(clientes);
            await _unitOfWork.SaveAsync();
            return clienteDto;
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}