using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Owners
{
    public interface IOwnersRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(int id);
        void Add(Owner owner);
        Task<bool> Update(Owner owner);
    }
}