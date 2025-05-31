using AnimalService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _animalRepository.GetAllAsync();
            return Ok(animals);
        }
    }
}
