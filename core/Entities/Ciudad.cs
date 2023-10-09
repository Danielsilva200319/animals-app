using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities;
public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdDep { get; set; }
    public Departamento Departamentos { get; set; }
    public ClienteDireccion ClientesDirecciones { get; set; }
}