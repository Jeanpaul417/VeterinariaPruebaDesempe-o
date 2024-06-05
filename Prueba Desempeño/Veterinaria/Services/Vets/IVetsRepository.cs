using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Vets
{
    public interface IVetsRepository
    {
         IEnumerable<Vet> GetAll();
        Vet GetById(int id);
    
    }
}