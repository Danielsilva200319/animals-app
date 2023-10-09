using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
public class Pais : BaseEntity
{
    public string NombrePais { get; set; }
    public ICollection<Departamento> Departamentos { get; set; }
}