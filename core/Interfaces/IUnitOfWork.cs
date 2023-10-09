using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises { get; }
        ICiudadRepository Ciudades { get; }
        IDepartamentoRepository Departamentos { get; }
        IClienteRepository Clientes { get; }
        IMascotaRepository Mascotas { get; }
        IRazaRepository Razas { get; }
        IServicioRepository Servicios { get; }
        IClienteTelRepository ClientesTels { get; }
        IClienteDirRepository ClientesDirs { get; }
        Task<int> SaveAsync();
    }
}