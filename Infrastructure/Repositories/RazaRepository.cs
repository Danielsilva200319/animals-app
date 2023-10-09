using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Core.Entities;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Repositories
{
    public class RazaRepository : GenericRepository<Raza>, IRazaRepository
    {
        private readonly AnimalsContext _context;

        public RazaRepository(AnimalsContext context) : base(context)
        {
            _context = context;
        }
    }
}