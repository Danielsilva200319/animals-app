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
    public class MascotaController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
        {
            var mascotas = await _unitOfWork.Mascotas.GetAllAsync();
            return _mapper.Map<List<MascotaDto>>(mascotas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>> Get(int id)
        {
            var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            return _mapper.Map<MascotaDto>(mascota);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto)
        {
            var mascota = _mapper.Map<Mascota>(mascotaDto);
            if (mascotaDto.FechaNacimiento == DateTime.MinValue)
            {
                mascotaDto.FechaNacimiento = DateTime.Now;
            }
            this._unitOfWork.Mascotas.Add(mascota);
            await _unitOfWork.SaveAsync();
            if (mascota == null)
            {
                return BadRequest();
            }
            mascotaDto.Id = mascota.Id;
            return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>> Put(string id, [FromBody] MascotaDto mascotaDto)
        {
            if (mascotaDto == null)
            {
                return NotFound();
            }
            var mascotas = _mapper.Map<Mascota>(mascotaDto);
            _unitOfWork.Mascotas.Update(mascotas);
            await _unitOfWork.SaveAsync();
            return mascotaDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mascota>> Delete(int id)
        {
            var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            _unitOfWork.Mascotas.Remove(mascota);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}