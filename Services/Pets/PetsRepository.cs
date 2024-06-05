using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;
using Veterinaria.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Services.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly BaseContext _context;

        public PetsRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets
          .Include(b => b.Owner).ToList();
        }

        public Pet GetById(int id)
        {
            var pet = _context.Pets
                    .Include(m => m.Owner)
                    .FirstOrDefault(m => m.Id == id);

            return pet;
        }

        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Pet pet)
        {

            var local = _context.Set<Pet>()
                .Local
                .FirstOrDefault(entry => entry.Id == pet.Id);

            if (local != null)
            {

                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pets.Any(e => e.Id == pet.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public IEnumerable<Pet> GetPetsByBirthDate(DateTime birthDate)
        {
            return _context.Pets
                .Where(p => p.DateBrith.Month == birthDate.Month && p.DateBrith.Day == birthDate.Day)
                .ToList();
        }
    }
}