using AnimalService.Domain.Classes;
using AnimalService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalService.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAnimals(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = new AnimalId(Guid.Parse("11111111-1111-1111-1111-111111111111")),
                    Type = AnimalType.Cat,
                    Name = "Dave the Cheese Wizard",
                    AgeInYears = 3
                },
                new Animal
                {
                    Id = new AnimalId(Guid.Parse("22222222-2222-2222-2222-222222222222")),
                    Type = AnimalType.Dog,
                    Name = "Honky",
                    AgeInYears = 5
                }
            );
        }
    }
}
