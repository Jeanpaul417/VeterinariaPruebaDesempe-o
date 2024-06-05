using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Owners;

namespace Veterinaria.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerUpdateController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnerUpdateController(IOwnersRepository ownerRepository)
        {
            _ownersRepository = ownerRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingOwner = _ownersRepository.GetById(id);
            if (existingOwner == null)
            {
                return NotFound();
            }

            bool updateResult = await _ownersRepository.Update(owner);

            if (!updateResult)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Usuario actualizado con exito");
        }
    }
}