using AnimalService.Api.Interface;
using System.ComponentModel.DataAnnotations;

namespace AnimalService.Api.Models
{
    public class UpdateAnimalDto : CreateAnimalDto, IAnimalData
    {
        [Required]
        public Guid Id { get; set; }
    }
}
