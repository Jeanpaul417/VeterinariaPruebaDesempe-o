using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;
using Veterinaria.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Services.Vets
{
    public class VetsRepository : IVetsRepository
    {
        private readonly BaseContext _context;

        public VetsRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Vet> GetAll()
        {
            return _context.Vets.ToList();
        }

        public Vet GetById(int id)
        {
            var vet = _context.Vets.Find(id);
            return vet;
        }


    }
}