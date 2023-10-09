using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Repositories
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
        private readonly AnimalsContext _context;

        public MascotaRepository(AnimalsContext context) : base(context)
        {
            _context = context;
        }
    }
}