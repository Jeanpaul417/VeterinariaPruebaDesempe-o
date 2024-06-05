using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Pets
{
    public interface IPetsRepository
    {
        
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        void Add(Pet pet);
        Task<bool> Update(Pet pet);
         IEnumerable<Pet> GetPetsByBirthDate(DateTime birthDate);
    }
}