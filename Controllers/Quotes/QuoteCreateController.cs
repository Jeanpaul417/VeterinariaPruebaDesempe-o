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
    public class QuoteCreateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuoteCreateController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Quote quote)
        {
            _quotesRepository.Add(quote);
            return Ok("Cita Creada con Exito");
        }
    }
}