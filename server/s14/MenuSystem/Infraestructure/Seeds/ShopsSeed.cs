using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using S14.MenuSystem.Domain;

namespace S14.MenuSystem.Infraestructure.Seeds
{
    public static class ShopsSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var categories = new List<MenuItemCategory>()
            {
                new MenuItemCategory { Id = 1, Name = "Platos principales", Description = "Platos principales de la cocina" },
                new MenuItemCategory { Id = 2, Name = "Entrantes", Description = "Platos para comenzar la comida" },
                new MenuItemCategory { Id = 3, Name = "Postres", Description = "Deliciosos postres para el final de la comida" },
                new MenuItemCategory { Id = 4, Name = "Bebidas", Description = "Refrescos y bebidas para acompañar tu comida" },
                new MenuItemCategory { Id = 5, Name = "Acompañamientos", Description = "Acompañamientos para tus platos principales" },
                new MenuItemCategory { Id = 6, Name = "Sopas y Ensaladas", Description = "Sopas reconfortantes y ensaladas frescas" },
                new MenuItemCategory { Id = 7, Name = "Especialidades de la Casa", Description = "Platos únicos de la casa" },
                new MenuItemCategory { Id = 8, Name = "Desayunos", Description = "Platos para comenzar el día con energía" },
                new MenuItemCategory { Id = 9, Name = "Cócteles", Description = "Cócteles refrescantes y deliciosos" },
                new MenuItemCategory { Id = 10, Name = "Platos Vegetarianos", Description = "Deliciosos platos sin carne" },
                new MenuItemCategory { Id = 11, Name = "Parrilladas", Description = "Variedad de carnes asadas a la parrilla" },
                new MenuItemCategory { Id = 12, Name = "Pizzas", Description = "Sabrosas pizzas recién horneadas" },
                new MenuItemCategory { Id = 13, Name = "Pastas", Description = "Platos de pasta tradicionales y deliciosos" },
                new MenuItemCategory { Id = 14, Name = "Tapas", Description = "Pequeños bocados para compartir" },
                new MenuItemCategory { Id = 15, Name = "Sushi y Sashimi", Description = "Auténtica comida japonesa" },
                new MenuItemCategory { Id = 16, Name = "Comida Mexicana", Description = "Sabores picantes y auténticos de México" },
                new MenuItemCategory { Id = 17, Name = "Comida Asiática", Description = "Delicias de la cocina asiática" },
                new MenuItemCategory { Id = 18, Name = "Comida Italiana", Description = "Sabores clásicos de Italia" },
                new MenuItemCategory { Id = 19, Name = "Comida Mediterránea", Description = "Platos inspirados en la dieta mediterránea" },
                new MenuItemCategory { Id = 20, Name = "Comida Americana", Description = "Clásicos de la cocina estadounidense" },
                new MenuItemCategory { Id = 21, Name = "Carnes", Description = "Carnes sabrosas y jugosas" }
            };


            var shops = new List<Shop>();

            // Información de la tienda "La Parrilla de Juan"
            var shopCarne = new Shop()
            {
                Id = 1,
                MallId = 1,
                Name = "La Parrilla de Juan",
                Description = "Auténtica comida argentina en el corazón de la ciudad.",
                Address = "Av. Principal 123",
                ImageUrl = new Uri("https://example.com/la-parrilla.jpg"),
                BannerUrl = new Uri("https://example.com/la-parrilla.jpg"),
                OpensAt = new TimeOnly(12, 0),
                ClosesAt = new TimeOnly(22, 0)
            };

            var menuCarnes = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1000,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Bife de Chorizo",
                    Description = "Corte de carne de vaca asado a la parrilla, jugoso y sabroso.",
                    Price = 28.99m,
                    ImageUrl = new Uri("https://example.com/bife-de-chorizo.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1001,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Matambre a la Pizza",
                    Description = "Matambre de cerdo cocido a la parrilla y cubierto con salsa de tomate y queso derretido.",
                    Price = 22.50m,
                    ImageUrl = new Uri("https://example.com/matambre-a-la-pizza.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1002,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Entraña a la Parrilla",
                    Description = "Jugosa entraña de vaca asada a la parrilla, tierna y sabrosa.",
                    Price = 30.75m,
                    ImageUrl = new Uri("https://example.com/entraña-a-la-parrilla.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1003,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Milanesa Napolitana",
                    Description = "Milanesa de carne empanada, cubierta con salsa de tomate, jamón y queso gratinado.",
                    Price = 18.99m,
                    ImageUrl = new Uri("https://example.com/milanesa-napolitana.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1004,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Choripán",
                    Description = "Pan con chorizo criollo a la parrilla, acompañado de chimichurri.",
                    Price = 9.50m,
                    ImageUrl = new Uri("https://example.com/choripan.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1005,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Parrillada Mixta",
                    Description = "Selección de carnes asadas: vacío, chorizo y morcilla.",
                    Price = 35.99m,
                    ImageUrl = new Uri("https://example.com/parrillada-mixta.jpg"),
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1006,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Lomo a la Pimienta",
                    Description = "Lomo de vaca asado a la parrilla y cubierto con una exquisita salsa de pimienta.",
                    Price = 32.50m,
                    ImageUrl = new Uri("https://example.com/lomo-a-la-pimienta.jpg"),

                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1007,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Chuletas de Cordero",
                    Description = "Chuletas de cordero marinadas y asadas a la parrilla.",
                    Price = 26.99m,
                    ImageUrl = new Uri("https://example.com/chuletas-de-cordero.jpg"),

                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1008,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Costillas BBQ",
                    Description = "Costillas de cerdo bañadas en salsa barbacoa y asadas a la parrilla.",
                    Price = 24.75m,
                    ImageUrl = new Uri("https://example.com/costillas-bbq.jpg"),

                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 1009,
                    ShopId = 1,
                    CategoryId = 21,
                    Name = "Solomillo al Whisky",
                    Description = "Solomillo de vaca flambeado al whisky, tierno y lleno de sabor.",
                    Price = 38.50m,
                    ImageUrl = new Uri("https://example.com/solomillo-al-whisky.jpg"),

                    IsAvailable = true
                }
            };

            var menuPizzas = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 2000,
                    Name = "Pizza Margarita",
                    Description = "Deliciosa pizza con salsa de tomate, mozzarella y albahaca fresca.",
                    Price = 12.99m,
                    ImageUrl = new Uri("https://example.com/pizza-margarita.jpg"),
                    CategoryId = 12, // Asignamos el ID de la categoría "Pizzas"
                    ShopId = 1, // Asignamos el ID de la tienda
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2001,
                    Name = "Pizza Pepperoni",
                    Description = "Pizza con salsa de tomate, mozzarella y rodajas de pepperoni.",
                    Price = 14.50m,
                    ImageUrl = new Uri("https://example.com/pizza-pepperoni.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2002,
                    Name = "Pizza Hawaiana",
                    Description = "Pizza con salsa de tomate, mozzarella, jamón y piña.",
                    Price = 13.75m,
                    ImageUrl = new Uri("https://example.com/pizza-hawaiana.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2003,
                    Name = "Pizza BBQ",
                    Description = "Pizza con salsa barbacoa, pollo, cebolla y mozzarella.",
                    Price = 16.99m,
                    ImageUrl = new Uri("https://example.com/pizza-bbq.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2004,
                    Name = "Pizza Vegetariana",
                    Description = "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.",
                    Price = 15.25m,
                    ImageUrl = new Uri("https://example.com/pizza-vegetariana.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2005,
                    Name = "Pizza Cuatro Quesos",
                    Description = "Pizza con salsa de tomate, mozzarella, queso azul, queso de cabra y parmesano.",
                    Price = 17.50m,
                    ImageUrl = new Uri("https://example.com/pizza-cuatro-quesos.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2006,
                    Name = "Pizza Mexicana",
                    Description = "Pizza con salsa de tomate, mozzarella, carne de res, jalapeños y guacamole.",
                    Price = 16.75m,
                    ImageUrl = new Uri("https://example.com/pizza-mexicana.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2007,
                    Name = "Pizza Caprese",
                    Description = "Pizza con salsa de tomate, mozzarella, tomate fresco y albahaca.",
                    Price = 15.99m,
                    ImageUrl = new Uri("https://example.com/pizza-caprese.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2008,
                    Name = "Pizza Siciliana",
                    Description = "Pizza con salsa de tomate, mozzarella, anchoas, aceitunas y alcaparras.",
                    Price = 18.25m,
                    ImageUrl = new Uri("https://example.com/pizza-siciliana.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2009,
                    Name = "Pizza Calzone",
                    Description = "Pizza cerrada y horneada, rellena de salsa de tomate, mozzarella y jamón.",
                    Price = 16.50m,
                    ImageUrl = new Uri("https://example.com/pizza-calzone.jpg"),
                    CategoryId = 12,
                    ShopId = 1,
                    IsAvailable = true
                }
            };

            var menuPastas = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 2011,
                    Name = "Espagueti Carbonara",
                    Description = "Espaguetis con salsa carbonara, panceta, huevo y queso parmesano.",
                    Price = 14.99m,
                    ImageUrl = new Uri("https://example.com/espagueti-carbonara.jpg"),
                    CategoryId = 13, // Asignamos el ID de la categoría "Pastas"
                    ShopId = 1, // Asignamos el ID de la tienda
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2012,
                    Name = "Fettuccine Alfredo",
                    Description = "Fettuccine con una cremosa salsa Alfredo de mantequilla y queso parmesano.",
                    Price = 16.50m,
                    ImageUrl = new Uri("https://example.com/fettuccine-alfredo.jpg"),
                    CategoryId = 13,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2013,
                    Name = "Lasaña Clásica",
                    Description = "Lasaña de carne con salsa de tomate, queso mozzarella y ricotta.",
                    Price = 17.25m,
                    ImageUrl = new Uri("https://example.com/lasana-clasica.jpg"),
                    CategoryId = 13,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2014,
                    Name = "Raviolis de Espinacas y Ricotta",
                    Description = "Raviolis rellenos de espinacas y ricotta, servidos con salsa de tomate.",
                    Price = 15.75m,
                    ImageUrl = new Uri("https://example.com/raviolis-espinacas-ricotta.jpg"),
                    CategoryId = 13,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2015,
                    Name = "Penne Arrabiata",
                    Description = "Penne con salsa de tomate picante, ajo y aceite de oliva.",
                    Price = 13.99m,
                    ImageUrl = new Uri("https://example.com/penne-arrabiata.jpg"),
                    CategoryId = 13,
                    ShopId = 1,
                    IsAvailable = true
                }
            };

            // Menú de platos vegetarianos
            var menuPlatosVegetarianos = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 2016,
                    Name = "Pizza Vegetariana",
                    Description = "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.",
                    Price = 15.25m,
                    ImageUrl = new Uri("https://example.com/pizza-vegetariana.jpg"),
                    CategoryId = 10, // Asignamos el ID de la categoría "Platos Vegetarianos"
                    ShopId = 1, // Asignamos el ID de la tienda
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2017,
                    Name = "Espaguetis Primavera",
                    Description = "Espaguetis con una variedad de vegetales de temporada y salsa de tomate.",
                    Price = 14.50m,
                    ImageUrl = new Uri("https://example.com/espaguetis-primavera.jpg"),
                    CategoryId = 10,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2018,
                    Name = "Ensalada Caprese",
                    Description = "Ensalada fresca con tomates, mozzarella, albahaca y aderezo balsámico.",
                    Price = 11.99m,
                    ImageUrl = new Uri("https://example.com/ensalada-caprese.jpg"),
                    CategoryId = 10,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2019,
                    Name = "Hamburguesa Vegetariana",
                    Description = "Hamburguesa vegana hecha con frijoles negros, quinoa y vegetales, servida con papas fritas.",
                    Price = 13.75m,
                    ImageUrl = new Uri("https://example.com/hamburguesa-vegetariana.jpg"),
                    CategoryId = 10,
                    ShopId = 1,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2020,
                    Name = "Wrap de Falafel",
                    Description = "Wrap relleno de falafel, hummus, verduras frescas y salsa tahini.",
                    Price = 12.50m,
                    ImageUrl = new Uri("https://example.com/wrap-falafel.jpg"),
                    CategoryId = 10,
                    ShopId = 1,
                    IsAvailable = true
                }
            };

            // Definición del shop para el mall con ID 1
            var shopPizzeria = new Shop
            {
                Id = 2,
                MallId = 1,
                Name = "Pizzería Italia",
                Description = "La mejor pizza al estilo italiano en la ciudad.",
                Address = "Calle Principal 456",
                ImageUrl = new Uri("https://example.com/pizzeria-italia.jpg"),
                BannerUrl = new Uri("https://example.com/la-parrilla.jpg"),
                OpensAt = TimeOnly.Parse("11:30"),
                ClosesAt = TimeOnly.Parse("23:00"),
            };

            // shopPizzeria.Menu.AddRange(menuPizzas.Concat(menuPastas).Concat(menuPlatosVegetarianos));

            // shopCarne.Menu.AddRange(menuCarnes);

            builder.Entity<MenuItemCategory>().HasData(categories);

            builder.Entity<Shop>().HasData(shopCarne);
            builder.Entity<MenuItem>().HasData(menuCarnes);

            var pizzaMenu = menuPizzas.Concat(menuPastas).Concat(menuPlatosVegetarianos);
            pizzaMenu.ToList().ForEach(x => x.ShopId = 2);
            builder.Entity<Shop>().HasData(shopPizzeria);
            builder.Entity<MenuItem>().HasData(pizzaMenu);
        }
    }
}
