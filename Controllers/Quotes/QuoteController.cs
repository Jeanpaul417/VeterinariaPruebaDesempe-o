using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Quotes;
using Veterinaria.Services.Pets;

namespace Veterinaria.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuoteController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetQuotes()
        {
            var quotes = _quotesRepository.GetAll();

            var result = quotes.Select(quote => new
            {
                quote.Id,
                quote.Date,
                Pet = quote.Pet?.Name,
                Vet = quote.Vet?.Names,
                quote.Description
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<object> Details(int id)
        {
            var quote = _quotesRepository.GetById(id);
            if (quote == null)
            {
                return NotFound();
            }

            var result = new
            {
                quote.Id,
                quote.Date,
                Pet = quote.Pet?.Name ?? string.Empty,
                Vet = quote.Vet?.Names ?? string.Empty,
                quote.Description
            };

            return Ok(result);
        }

        [HttpGet("cantidadCitasFecha/{fecha}")]
        public ActionResult<IEnumerable<Quote>> GetQuoteByDate(DateTime fecha)
        {
            var CantiQuotes = _quotesRepository.GetQuoteByDate(fecha);
            return Ok(CantiQuotes);
        }

        [HttpGet("mascotasDueño/{ownerId}")]
        public ActionResult<IEnumerable<Quote>> GetPetsByOwnerId(int ownerId)
        {
            var pets = _quotesRepository.GetPetsByOwnerId(ownerId);
            return Ok(pets);
        }

        // Obtener todas las citas de un veterinario específico

        [HttpGet("citasVeterinario/{vetId}")]
        public ActionResult<IEnumerable<Quote>> GetQuotesByVetId(int vetId)
        {
            var vets = _quotesRepository.GetPetsByOwnerId(vetId);

            return Ok(vets);
        }

    }
}