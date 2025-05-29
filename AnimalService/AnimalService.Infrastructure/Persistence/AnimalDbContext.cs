using AnimalService.Domain.Classes;
using AnimalService.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Identifiers;


namespace AnimalService.Infrastructure.Persistence
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>(builder => {
                builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasConversion(
                        id => id.Value,
                        value => new AnimalId(value)
                    );

                builder.Property(a => a.Type)
                    .HasConversion<string>();
            });

            modelBuilder.SeedAnimals();
        }
    }
}
