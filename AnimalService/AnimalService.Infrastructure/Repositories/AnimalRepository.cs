using AnimalService.Application.Interfaces;
using AnimalService.Domain.Classes;
using AnimalService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalService.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalDbContext _context;

        public AnimalRepository(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Animal>> GetAllAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal?> GetByIdAsync(AnimalId id)
        {
            return await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task RemoveAsync(AnimalId id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
            if (animal == null)
            {
                throw new KeyNotFoundException($"Animal with ID {id} not found.");
            }
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }
}
