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
    public class PetUpdateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetUpdateController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingPet = _petsRepository.GetById(id);
            if (existingPet == null)
            {
                return NotFound();
            }

            bool updateResult = await _petsRepository.Update(pet);

            if (!updateResult)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Mascota actualizada con exito");
        }
    }
}