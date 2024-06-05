using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Quotes
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetAll();
        Quote GetById(int id);
        void Add(Quote quote);
        Task<bool> Update(Quote quote);

        List<Quote> GetQuoteByDate(DateTime fecha);

        public IEnumerable<Pet> GetPetsByOwnerId(int ownerId);
        IEnumerable<Quote> GetQuotesByVetId(int vetId);

       


    }
}