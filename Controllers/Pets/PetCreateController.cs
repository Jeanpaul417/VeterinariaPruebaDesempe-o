using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Pets;

namespace Veterinaria.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetCreateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetCreateController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet pet)
        {
            _petsRepository.Add(pet);
            return Ok("Mascota Creada con exito");
        }

    }
}