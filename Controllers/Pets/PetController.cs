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
    public class PetController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetPets()
        {
            var pets = _petsRepository.GetAll();

            var result = pets.Select(pet => new
            {
                pet.Id,
                pet.Name,
                pet.Specie,
                pet.Race,
                pet.DateBrith,
                Owner = pet.Owner?.Names
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<object> Details(int id)
        {
            var pet = _petsRepository.GetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            var result = new
            {
                pet.Id,
                pet.Name,
                pet.Specie,
                pet.Race,
                pet.DateBrith,
                Owner = pet.Owner?.Names ?? string.Empty
            };

            return Ok(result);
        }


        [HttpGet("mascotasPorCumpleaños/{fecha}")]
        public ActionResult<IEnumerable<Pet>> GetPetsByBirthDate(DateTime fecha)
        {
            var pets = _petsRepository.GetPetsByBirthDate(fecha);
            if (pets == null || !pets.Any())
            {
                return NotFound("No pets found for the provided birth date.");
            }

            return Ok(pets);
        }
    }
}