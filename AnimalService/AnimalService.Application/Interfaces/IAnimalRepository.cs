using AnimalService.Domain.Classes;
using SharedKernel.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalService.Application.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAllAsync();
        Task<Animal?> GetByIdAsync(AnimalId id);
        Task AddAsync(Animal animal);
    }
}
