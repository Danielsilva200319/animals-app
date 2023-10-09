using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Repositories
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        private readonly AnimalsContext _context;

        public ServicioRepository(AnimalsContext context) : base(context)
        {
            _context = context;
        }
    }
}