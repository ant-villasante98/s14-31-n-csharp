﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S14.MenuSystem.Infraestructure;

#nullable disable

namespace S14.MenuSystem.Infraestructure.Migrations
{
    [DbContext(typeof(MenuSystemContext))]
    [Migration("20240414133230_S2")]
    partial class S2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MS")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("S14.MenuSystem.Domain.Mall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("ClosesAt")
                        .HasColumnType("time");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("OpensAt")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Malls", "MS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Calle Principal 123",
                            ClosesAt = new TimeOnly(21, 0, 0),
                            Description = "El centro comercial más grande de la ciudad",
                            ImageUrl = "https://example.com/imagen1.jpg",
                            Name = "Centro Comercial Central",
                            OpensAt = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Avenida del Este 456",
                            ClosesAt = new TimeOnly(22, 0, 0),
                            Description = "Un lugar perfecto para ir de compras y pasar tiempo en familia",
                            ImageUrl = "https://example.com/imagen2.jpg",
                            Name = "Centro Comercial del Este",
                            OpensAt = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Address = "Plaza Principal 789",
                            ClosesAt = new TimeOnly(20, 30, 0),
                            Description = "Un oasis de tiendas y restaurantes en el corazón de la ciudad",
                            ImageUrl = "https://example.com/imagen3.jpg",
                            Name = "Centro Comercial Oasis",
                            OpensAt = new TimeOnly(8, 30, 0)
                        },
                        new
                        {
                            Id = 4,
                            Address = "Calle Real 1011",
                            ClosesAt = new TimeOnly(21, 30, 0),
                            Description = "Un destino de compras con una amplia variedad de tiendas y servicios",
                            ImageUrl = "https://example.com/imagen4.jpg",
                            Name = "Centro Comercial Plaza Real",
                            OpensAt = new TimeOnly(9, 30, 0)
                        },
                        new
                        {
                            Id = 5,
                            Address = "Avenida Bella Vista 1213",
                            ClosesAt = new TimeOnly(23, 0, 0),
                            Description = "Con una vista panorámica de la ciudad, este centro comercial ofrece una experiencia única de compras",
                            ImageUrl = "https://example.com/imagen5.jpg",
                            Name = "Centro Comercial Bella Vista",
                            OpensAt = new TimeOnly(11, 0, 0)
                        });
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ShopId");

                    b.ToTable("Items", "MS");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            CategoryId = 21,
                            Description = "Corte de carne de vaca asado a la parrilla, jugoso y sabroso.",
                            ImageUrl = "https://example.com/bife-de-chorizo.jpg",
                            IsAvailable = true,
                            Name = "Bife de Chorizo",
                            Price = 28.99m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1001,
                            CategoryId = 21,
                            Description = "Matambre de cerdo cocido a la parrilla y cubierto con salsa de tomate y queso derretido.",
                            ImageUrl = "https://example.com/matambre-a-la-pizza.jpg",
                            IsAvailable = true,
                            Name = "Matambre a la Pizza",
                            Price = 22.50m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1002,
                            CategoryId = 21,
                            Description = "Jugosa entraña de vaca asada a la parrilla, tierna y sabrosa.",
                            ImageUrl = "https://example.com/entraña-a-la-parrilla.jpg",
                            IsAvailable = true,
                            Name = "Entraña a la Parrilla",
                            Price = 30.75m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1003,
                            CategoryId = 21,
                            Description = "Milanesa de carne empanada, cubierta con salsa de tomate, jamón y queso gratinado.",
                            ImageUrl = "https://example.com/milanesa-napolitana.jpg",
                            IsAvailable = true,
                            Name = "Milanesa Napolitana",
                            Price = 18.99m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1004,
                            CategoryId = 21,
                            Description = "Pan con chorizo criollo a la parrilla, acompañado de chimichurri.",
                            ImageUrl = "https://example.com/choripan.jpg",
                            IsAvailable = true,
                            Name = "Choripán",
                            Price = 9.50m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1005,
                            CategoryId = 21,
                            Description = "Selección de carnes asadas: vacío, chorizo y morcilla.",
                            ImageUrl = "https://example.com/parrillada-mixta.jpg",
                            IsAvailable = true,
                            Name = "Parrillada Mixta",
                            Price = 35.99m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1006,
                            CategoryId = 21,
                            Description = "Lomo de vaca asado a la parrilla y cubierto con una exquisita salsa de pimienta.",
                            ImageUrl = "https://example.com/lomo-a-la-pimienta.jpg",
                            IsAvailable = true,
                            Name = "Lomo a la Pimienta",
                            Price = 32.50m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1007,
                            CategoryId = 21,
                            Description = "Chuletas de cordero marinadas y asadas a la parrilla.",
                            ImageUrl = "https://example.com/chuletas-de-cordero.jpg",
                            IsAvailable = true,
                            Name = "Chuletas de Cordero",
                            Price = 26.99m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1008,
                            CategoryId = 21,
                            Description = "Costillas de cerdo bañadas en salsa barbacoa y asadas a la parrilla.",
                            ImageUrl = "https://example.com/costillas-bbq.jpg",
                            IsAvailable = true,
                            Name = "Costillas BBQ",
                            Price = 24.75m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 1009,
                            CategoryId = 21,
                            Description = "Solomillo de vaca flambeado al whisky, tierno y lleno de sabor.",
                            ImageUrl = "https://example.com/solomillo-al-whisky.jpg",
                            IsAvailable = true,
                            Name = "Solomillo al Whisky",
                            Price = 38.50m,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2000,
                            CategoryId = 12,
                            Description = "Deliciosa pizza con salsa de tomate, mozzarella y albahaca fresca.",
                            ImageUrl = "https://example.com/pizza-margarita.jpg",
                            IsAvailable = true,
                            Name = "Pizza Margarita",
                            Price = 12.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2001,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella y rodajas de pepperoni.",
                            ImageUrl = "https://example.com/pizza-pepperoni.jpg",
                            IsAvailable = true,
                            Name = "Pizza Pepperoni",
                            Price = 14.50m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2002,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, jamón y piña.",
                            ImageUrl = "https://example.com/pizza-hawaiana.jpg",
                            IsAvailable = true,
                            Name = "Pizza Hawaiana",
                            Price = 13.75m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2003,
                            CategoryId = 12,
                            Description = "Pizza con salsa barbacoa, pollo, cebolla y mozzarella.",
                            ImageUrl = "https://example.com/pizza-bbq.jpg",
                            IsAvailable = true,
                            Name = "Pizza BBQ",
                            Price = 16.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2004,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.",
                            ImageUrl = "https://example.com/pizza-vegetariana.jpg",
                            IsAvailable = true,
                            Name = "Pizza Vegetariana",
                            Price = 15.25m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2005,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, queso azul, queso de cabra y parmesano.",
                            ImageUrl = "https://example.com/pizza-cuatro-quesos.jpg",
                            IsAvailable = true,
                            Name = "Pizza Cuatro Quesos",
                            Price = 17.50m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2006,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, carne de res, jalapeños y guacamole.",
                            ImageUrl = "https://example.com/pizza-mexicana.jpg",
                            IsAvailable = true,
                            Name = "Pizza Mexicana",
                            Price = 16.75m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2007,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, tomate fresco y albahaca.",
                            ImageUrl = "https://example.com/pizza-caprese.jpg",
                            IsAvailable = true,
                            Name = "Pizza Caprese",
                            Price = 15.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2008,
                            CategoryId = 12,
                            Description = "Pizza con salsa de tomate, mozzarella, anchoas, aceitunas y alcaparras.",
                            ImageUrl = "https://example.com/pizza-siciliana.jpg",
                            IsAvailable = true,
                            Name = "Pizza Siciliana",
                            Price = 18.25m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2009,
                            CategoryId = 12,
                            Description = "Pizza cerrada y horneada, rellena de salsa de tomate, mozzarella y jamón.",
                            ImageUrl = "https://example.com/pizza-calzone.jpg",
                            IsAvailable = true,
                            Name = "Pizza Calzone",
                            Price = 16.50m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2011,
                            CategoryId = 13,
                            Description = "Espaguetis con salsa carbonara, panceta, huevo y queso parmesano.",
                            ImageUrl = "https://example.com/espagueti-carbonara.jpg",
                            IsAvailable = true,
                            Name = "Espagueti Carbonara",
                            Price = 14.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2012,
                            CategoryId = 13,
                            Description = "Fettuccine con una cremosa salsa Alfredo de mantequilla y queso parmesano.",
                            ImageUrl = "https://example.com/fettuccine-alfredo.jpg",
                            IsAvailable = true,
                            Name = "Fettuccine Alfredo",
                            Price = 16.50m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2013,
                            CategoryId = 13,
                            Description = "Lasaña de carne con salsa de tomate, queso mozzarella y ricotta.",
                            ImageUrl = "https://example.com/lasana-clasica.jpg",
                            IsAvailable = true,
                            Name = "Lasaña Clásica",
                            Price = 17.25m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2014,
                            CategoryId = 13,
                            Description = "Raviolis rellenos de espinacas y ricotta, servidos con salsa de tomate.",
                            ImageUrl = "https://example.com/raviolis-espinacas-ricotta.jpg",
                            IsAvailable = true,
                            Name = "Raviolis de Espinacas y Ricotta",
                            Price = 15.75m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2015,
                            CategoryId = 13,
                            Description = "Penne con salsa de tomate picante, ajo y aceite de oliva.",
                            ImageUrl = "https://example.com/penne-arrabiata.jpg",
                            IsAvailable = true,
                            Name = "Penne Arrabiata",
                            Price = 13.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2016,
                            CategoryId = 10,
                            Description = "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.",
                            ImageUrl = "https://example.com/pizza-vegetariana.jpg",
                            IsAvailable = true,
                            Name = "Pizza Vegetariana",
                            Price = 15.25m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2017,
                            CategoryId = 10,
                            Description = "Espaguetis con una variedad de vegetales de temporada y salsa de tomate.",
                            ImageUrl = "https://example.com/espaguetis-primavera.jpg",
                            IsAvailable = true,
                            Name = "Espaguetis Primavera",
                            Price = 14.50m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2018,
                            CategoryId = 10,
                            Description = "Ensalada fresca con tomates, mozzarella, albahaca y aderezo balsámico.",
                            ImageUrl = "https://example.com/ensalada-caprese.jpg",
                            IsAvailable = true,
                            Name = "Ensalada Caprese",
                            Price = 11.99m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2019,
                            CategoryId = 10,
                            Description = "Hamburguesa vegana hecha con frijoles negros, quinoa y vegetales, servida con papas fritas.",
                            ImageUrl = "https://example.com/hamburguesa-vegetariana.jpg",
                            IsAvailable = true,
                            Name = "Hamburguesa Vegetariana",
                            Price = 13.75m,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 2020,
                            CategoryId = 10,
                            Description = "Wrap relleno de falafel, hummus, verduras frescas y salsa tahini.",
                            ImageUrl = "https://example.com/wrap-falafel.jpg",
                            IsAvailable = true,
                            Name = "Wrap de Falafel",
                            Price = 12.50m,
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.MenuItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "MS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Platos principales de la cocina",
                            Name = "Platos principales"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Platos para comenzar la comida",
                            Name = "Entrantes"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Deliciosos postres para el final de la comida",
                            Name = "Postres"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Refrescos y bebidas para acompañar tu comida",
                            Name = "Bebidas"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Acompañamientos para tus platos principales",
                            Name = "Acompañamientos"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Sopas reconfortantes y ensaladas frescas",
                            Name = "Sopas y Ensaladas"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Platos únicos de la casa",
                            Name = "Especialidades de la Casa"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Platos para comenzar el día con energía",
                            Name = "Desayunos"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Cócteles refrescantes y deliciosos",
                            Name = "Cócteles"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Deliciosos platos sin carne",
                            Name = "Platos Vegetarianos"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Variedad de carnes asadas a la parrilla",
                            Name = "Parrilladas"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Sabrosas pizzas recién horneadas",
                            Name = "Pizzas"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Platos de pasta tradicionales y deliciosos",
                            Name = "Pastas"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Pequeños bocados para compartir",
                            Name = "Tapas"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Auténtica comida japonesa",
                            Name = "Sushi y Sashimi"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Sabores picantes y auténticos de México",
                            Name = "Comida Mexicana"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Delicias de la cocina asiática",
                            Name = "Comida Asiática"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Sabores clásicos de Italia",
                            Name = "Comida Italiana"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Platos inspirados en la dieta mediterránea",
                            Name = "Comida Mediterránea"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Clásicos de la cocina estadounidense",
                            Name = "Comida Americana"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Carnes sabrosas y jugosas",
                            Name = "Carnes"
                        });
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ShopId");

                    b.ToTable("Promotion", "MS");
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("AgentIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("ClosesAt")
                        .HasColumnType("time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MallId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("OpensAt")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("MallId");

                    b.ToTable("Shops", "MS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Av. Principal 123",
                            AdminId = 0,
                            BannerUrl = "https://example.com/la-parrilla.jpg",
                            ClosesAt = new TimeOnly(22, 0, 0),
                            Description = "Auténtica comida argentina en el corazón de la ciudad.",
                            ImageUrl = "https://example.com/la-parrilla.jpg",
                            MallId = 1,
                            Name = "La Parrilla de Juan",
                            OpensAt = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Calle Principal 456",
                            AdminId = 0,
                            BannerUrl = "https://example.com/la-parrilla.jpg",
                            ClosesAt = new TimeOnly(23, 0, 0),
                            Description = "La mejor pizza al estilo italiano en la ciudad.",
                            ImageUrl = "https://example.com/pizzeria-italia.jpg",
                            MallId = 1,
                            Name = "Pizzería Italia",
                            OpensAt = new TimeOnly(11, 30, 0)
                        });
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.MenuItem", b =>
                {
                    b.HasOne("S14.MenuSystem.Domain.MenuItemCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S14.MenuSystem.Domain.Shop", "Shop")
                        .WithMany("Menu")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Promotion", b =>
                {
                    b.HasOne("S14.MenuSystem.Domain.MenuItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S14.MenuSystem.Domain.Shop", null)
                        .WithMany("Promotions")
                        .HasForeignKey("ShopId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Shop", b =>
                {
                    b.HasOne("S14.MenuSystem.Domain.Mall", "Mall")
                        .WithMany("Shops")
                        .HasForeignKey("MallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mall");
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Mall", b =>
                {
                    b.Navigation("Shops");
                });

            modelBuilder.Entity("S14.MenuSystem.Domain.Shop", b =>
                {
                    b.Navigation("Menu");

                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
