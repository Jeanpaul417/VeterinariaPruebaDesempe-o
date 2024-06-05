using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;
using Veterinaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Veterinaria.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _context;

        public QuotesRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes
          .Include(b => b.Vet)
          .Include(b => b.Pet).ToList();
        }

        public Quote GetById(int id)
        {
            var quote = _context.Quotes
                    .Include(m => m.Vet)
                    .Include(m => m.Pet)
                    .FirstOrDefault(m => m.Id == id);

            return quote;
        }

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Quote quote)
        {

            var local = _context.Set<Quote>()
                .Local
                .FirstOrDefault(entry => entry.Id == quote.Id);

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }


            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Quotes.Any(e => e.Id == quote.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /* Listar citas en una fecha especifica */
        public List<Quote> GetQuoteByDate(DateTime fecha)
        {
            return _context.Quotes.Where(c => c.Date.Date == fecha.Date).ToList();
        }

        /* Listar todas las mascotas de un dueño */

        public IEnumerable<Pet> GetPetsByOwnerId(int ownerId)
        {
            return _context.Pets
                .Where(p => p.OwnerId == ownerId)
                .ToList();
        }

       public IEnumerable<Quote> GetQuotesByVetId(int vetId)
        {
            return _context.Quotes
                .Where(q => q.VetId == vetId)
                .Include(q => q.Pet)
                .ToList();
        }

    }
}