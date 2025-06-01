using AnimalService.Api.Interface;
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
            Type = animal.Type.ToString(),
            Name = animal.Name,
            AgeInYears = animal.AgeInYears
        };

        public static Animal MapToDomain(AnimalDto dto) => new()
        {
            Id = new AnimalId(dto.Id),
            Type = Enum.Parse<AnimalType>(dto.Type),
            Name = dto.Name,
            AgeInYears = dto.AgeInYears
        };

        public static Animal MapToDomain(IAnimalData data, AnimalId id) => new()
        {
            Id = id,
            Type = Enum.Parse<AnimalType>(data.Type),
            Name = data.Name,
            AgeInYears = data.AgeInYears
        };
    }
}
