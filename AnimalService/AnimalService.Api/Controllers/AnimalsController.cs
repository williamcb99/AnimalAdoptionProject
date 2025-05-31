using AnimalService.Api.Mapping;
using AnimalService.Api.Models;
using AnimalService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Identifiers;

namespace AnimalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [EndpointDescription("Get all animals")]
        [EndpointSummary("Get all animals")]
        [Tags("Animals")]
        [ProducesResponseType(typeof(List<AnimalDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = (await _animalRepository.GetAllAsync())?.ToList();
            if (animals == null)
            {
                return Problem("Animal repository returned null.");
            }
            var animalDtos = animals.Select(AnimalMapper.MapToDto).ToList();
            return Ok(animalDtos);
        }

        [EndpointDescription("Get animal by ID")]
        [EndpointSummary("Get animal by ID")]
        [Tags("Animals")]
        [ProducesResponseType(typeof(AnimalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("GetAnimalById/{id:guid}")]
        public async Task<IActionResult> GetAnimalById([FromRoute] Guid id)
        {
            var animalId = new AnimalId(id);
            var animal = await _animalRepository.GetByIdAsync(animalId);
            if (animal == null)
            {
                return NotFound($"Animal with ID {id} not found.");
            }
            return Ok(AnimalMapper.MapToDto(animal));
        }
    }
}
