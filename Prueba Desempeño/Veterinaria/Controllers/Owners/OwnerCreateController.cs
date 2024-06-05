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
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnerCreateController(IOwnersRepository ownerRepository)
        {
            _ownersRepository = ownerRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Owner owner)
        {
            _ownersRepository.Add(owner);
            return Ok("Usuario registrado con exito");
        }
    }
}