using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using S14.MenuSystem.Domain;

namespace S14.UserManagment.Infraestructure
{
    public static class MallsSeed
    {
        public static void Seed(ModelBuilder builder)
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var malls = new[]
            {
                new Mall
                {
                    Id = 1,
                    Name = "Centro Comercial Central",
                    Description = "El centro comercial más grande de la ciudad",
                    Address = "Calle Principal 123",
                    ImageUrl = new Uri("https://example.com/imagen1.jpg"),
                    OpensAt = new TimeOnly(9, 0), // Abre a las 9:00 AM
                    ClosesAt = new TimeOnly(21, 0) // Cierra a las 9:00 PM
                },
                new Mall
                {
                    Id = 2,
                    Name = "Centro Comercial del Este",
                    Description = "Un lugar perfecto para ir de compras y pasar tiempo en familia",
                    Address = "Avenida del Este 456",
                    ImageUrl = new Uri("https://example.com/imagen2.jpg"),
                    OpensAt = new TimeOnly(10, 0), // Abre a las 10:00 AM
                    ClosesAt = new TimeOnly(22, 0) // Cierra a las 10:00 PM
                },
                new Mall
                {
                    Id = 3,
                    Name = "Centro Comercial Oasis",
                    Description = "Un oasis de tiendas y restaurantes en el corazón de la ciudad",
                    Address = "Plaza Principal 789",
                    ImageUrl = new Uri("https://example.com/imagen3.jpg"),
                    OpensAt = new TimeOnly(8, 30), // Abre a las 8:30 AM
                    ClosesAt = new TimeOnly(20, 30) // Cierra a las 8:30 PM
                },
                new Mall
                {
                    Id = 4,
                    Name = "Centro Comercial Plaza Real",
                    Description = "Un destino de compras con una amplia variedad de tiendas y servicios",
                    Address = "Calle Real 1011",
                    ImageUrl = new Uri("https://example.com/imagen4.jpg"),
                    OpensAt = new TimeOnly(9, 30), // Abre a las 9:30 AM
                    ClosesAt = new TimeOnly(21, 30) // Cierra a las 9:30 PM
                },
                new Mall
                {
                    Id = 5,
                    Name = "Centro Comercial Bella Vista",
                    Description = "Con una vista panorámica de la ciudad, este centro comercial ofrece una experiencia única de compras",
                    Address = "Avenida Bella Vista 1213",
                    ImageUrl = new Uri("https://example.com/imagen5.jpg"),
                    OpensAt = new TimeOnly(11, 0), // Abre a las 11:00 AM
                    ClosesAt = new TimeOnly(23, 0) // Cierra a las 11:00 PM
                }
            };

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            builder.Entity<Mall>().HasData(malls);
        }
    }
}
