using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Quotes;

namespace Veterinaria.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteUpdateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuoteUpdateController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Quote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingQuote = _quotesRepository.GetById(id);
            if (existingQuote == null)
            {
                return NotFound();
            }

            bool updateResult = await _quotesRepository.Update(quote);

            if (!updateResult)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Cita Actualizada con exito");
        }
    }
}