using AnimalService.Api.Models;
using AnimalService.Domain.Classes;
using AnimalService.Domain.Enums;
using SharedKernel.Identifiers;

namespace AnimalService.Api.Mapping
{
    public static class AnimalMapper
    {
        public static AnimalDto MapToDto(Animal animal) => new()
        {
            Id = animal.Id.Value,
            Type = animal.Type,
            Name = animal.Name,
            AgeInYears = animal.AgeInYears
        };

        public static Animal MapToDomain(AnimalDto dto) => new()
        {
            Id = new AnimalId(dto.Id),
            Type = dto.Type,
            Name = dto.Name,
            AgeInYears = dto.AgeInYears
        };

        public static Animal MapToDomain(AnimalDto dto, AnimalId id) => new()
        {
            Id = id,
            Type = dto.Type,
            Name = dto.Name,
            AgeInYears = dto.AgeInYears
        };

    }
}
