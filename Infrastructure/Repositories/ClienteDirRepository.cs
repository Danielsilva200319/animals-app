using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Repositories
{
    public class ClienteDirRepository : GenericRepository<ClienteDireccion>, IClienteDirRepository
    {
        private readonly AnimalsContext _context;

        public ClienteDirRepository(AnimalsContext context) : base(context)
        {
            _context = context;
        }
    }
}