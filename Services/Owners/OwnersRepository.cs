using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;
using Veterinaria.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly BaseContext _context;

        public OwnersRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner GetById(int id)
        {
            var owner = _context.Owners.Find(id);
            return owner;
        }

        public void Add(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Owner owner)
        {
            // Desacopla la entidad si ya está siendo rastreada
            var local = _context.Set<Owner>()
                .Local
                .FirstOrDefault(entry => entry.Id == owner.Id);

            if (local != null)
            {
                // Desacopla la entidad local
                _context.Entry(local).State = EntityState.Detached;
            }

            // Adjunta la entidad y marca su estado como modificado
            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Owners.Any(e => e.Id == owner.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}