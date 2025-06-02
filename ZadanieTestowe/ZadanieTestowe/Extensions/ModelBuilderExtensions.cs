using Microsoft.EntityFrameworkCore;
using ZadanieTestowe.Models;

namespace ZadanieTestowe.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Town>().HasData(
            new Town
            {
                Id = Guid.NewGuid(),
                Name = "Warszawa"
            },
            new Town
            {
                Id = Guid.NewGuid(),
                Name = "Kraków"
            },
            new Town
            {
                Id = Guid.NewGuid(),
                Name = "London"
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Nokia"
            }
        );

        modelBuilder.Entity<Keyword>().HasData(
            new Keyword
            {
                Id = Guid.NewGuid(),
                Name = "Phone"
            },
            new Keyword
            {
                Id = Guid.NewGuid(),
                Name = "Mobile"
            },
            new Keyword
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone"
            }
        );

    }

}