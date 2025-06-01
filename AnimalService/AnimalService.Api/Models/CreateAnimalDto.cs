using AnimalService.Api.Interface;
using AnimalService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnimalService.Api.Models
{
    public class CreateAnimalDto : IAnimalData
    {
        [Required]
        [EnumDataType(typeof(AnimalType))]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int AgeInYears { get; set; }
    }
}
