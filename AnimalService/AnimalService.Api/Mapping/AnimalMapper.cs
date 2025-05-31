using AnimalService.Api.Models;
using AnimalService.Domain.Classes;

namespace AnimalService.Api.Mapping
{
    public static class AnimalMapper
    {
        public static AnimalDto MapToDto(Animal animal) => new()
        {
            Id = animal.Id.Value,
            Type = animal.Type.ToString(),
            Name = animal.Name,
            AgeInYears = animal.AgeInYears
        };
    }
}
