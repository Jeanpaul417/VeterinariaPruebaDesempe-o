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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnerController(IOwnersRepository ownerRepository)
        {
            _ownersRepository = ownerRepository;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwers()
        {
            return _ownersRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Owner Details(int id)
        {
            return _ownersRepository.GetById(id);
        }
    }
}