using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Vets;

namespace Veterinaria.Controllers.Vets
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;
        public VetController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }

        [HttpGet]
        public IEnumerable<Vet> GetOwers()
        {
            return _vetsRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Vet Details(int id)
        {
            return _vetsRepository.GetById(id);
        }
    }
}