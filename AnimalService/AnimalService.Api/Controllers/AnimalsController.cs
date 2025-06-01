using AnimalService.Api.Mapping;
using AnimalService.Api.Models;
using AnimalService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Identifiers;
using System.Reflection.Metadata.Ecma335;

namespace AnimalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet("GetAllAnimals")]
        [EndpointDescription("Get all animals")]
        [EndpointSummary("Get all animals")]
        [ProducesResponseType(typeof(List<AnimalDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
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

        [HttpGet("GetAnimalById/{id:guid}")]
        [EndpointDescription("Get animal by ID")]
        [EndpointSummary("Get animal by ID")]
        [ProducesResponseType(typeof(AnimalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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

        [HttpDelete("RemoveAnimal/{id:guid}")]
        [EndpointDescription("Remove animal by ID")]
        [EndpointSummary("Remove animal by ID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAnimal([FromRoute] Guid id)
        {
            var animalId = new AnimalId(id);
            try
            {
                await _animalRepository.RemoveAsync(animalId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Animal with ID {id} not found.");
            }
        }

        [HttpPost("AddAnimal")]
        [EndpointDescription("Create animal")]
        [EndpointSummary("Create animal")]
        [ProducesResponseType(typeof(AnimalDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAnimal([FromBody] CreateAnimalDto newAnimal)
        {
            if (newAnimal == null)
                return BadRequest("Request body cannot be empty.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);            
            var animalId = new AnimalId(Guid.NewGuid());
            var animal = AnimalMapper.MapToDomain(newAnimal, animalId);
            await _animalRepository.AddAsync(animal);
            var createdAnimalDto = AnimalMapper.MapToDto(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = createdAnimalDto.Id }, createdAnimalDto);
        }
    }
}
