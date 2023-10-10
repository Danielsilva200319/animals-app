using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace core.Entities
{
    public class Mascota : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Especie { get; set; }
        [Required]
        public int IdRaza { get; set; }
        public Raza Razas { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}