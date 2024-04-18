using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace S14.MenuSystem.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class S2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MS");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "MS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malls",
                schema: "MS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpensAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    ClosesAt = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                schema: "MS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MallId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    ClosesAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    AgentIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Malls_MallId",
                        column: x => x.MallId,
                        principalSchema: "MS",
                        principalTable: "Malls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "MS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "MS",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Shops_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "MS",
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                schema: "MS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "MS",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promotion_Shops_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "MS",
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "MS",
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Platos principales de la cocina", "Platos principales" },
                    { 2, "Platos para comenzar la comida", "Entrantes" },
                    { 3, "Deliciosos postres para el final de la comida", "Postres" },
                    { 4, "Refrescos y bebidas para acompañar tu comida", "Bebidas" },
                    { 5, "Acompañamientos para tus platos principales", "Acompañamientos" },
                    { 6, "Sopas reconfortantes y ensaladas frescas", "Sopas y Ensaladas" },
                    { 7, "Platos únicos de la casa", "Especialidades de la Casa" },
                    { 8, "Platos para comenzar el día con energía", "Desayunos" },
                    { 9, "Cócteles refrescantes y deliciosos", "Cócteles" },
                    { 10, "Deliciosos platos sin carne", "Platos Vegetarianos" },
                    { 11, "Variedad de carnes asadas a la parrilla", "Parrilladas" },
                    { 12, "Sabrosas pizzas recién horneadas", "Pizzas" },
                    { 13, "Platos de pasta tradicionales y deliciosos", "Pastas" },
                    { 14, "Pequeños bocados para compartir", "Tapas" },
                    { 15, "Auténtica comida japonesa", "Sushi y Sashimi" },
                    { 16, "Sabores picantes y auténticos de México", "Comida Mexicana" },
                    { 17, "Delicias de la cocina asiática", "Comida Asiática" },
                    { 18, "Sabores clásicos de Italia", "Comida Italiana" },
                    { 19, "Platos inspirados en la dieta mediterránea", "Comida Mediterránea" },
                    { 20, "Clásicos de la cocina estadounidense", "Comida Americana" },
                    { 21, "Carnes sabrosas y jugosas", "Carnes" }
                });

            migrationBuilder.InsertData(
                schema: "MS",
                table: "Malls",
                columns: new[] { "Id", "Address", "ClosesAt", "Description", "ImageUrl", "Name", "OpensAt" },
                values: new object[,]
                {
                    { 1, "Calle Principal 123", new TimeOnly(21, 0, 0), "El centro comercial más grande de la ciudad", "https://example.com/imagen1.jpg", "Centro Comercial Central", new TimeOnly(9, 0, 0) },
                    { 2, "Avenida del Este 456", new TimeOnly(22, 0, 0), "Un lugar perfecto para ir de compras y pasar tiempo en familia", "https://example.com/imagen2.jpg", "Centro Comercial del Este", new TimeOnly(10, 0, 0) },
                    { 3, "Plaza Principal 789", new TimeOnly(20, 30, 0), "Un oasis de tiendas y restaurantes en el corazón de la ciudad", "https://example.com/imagen3.jpg", "Centro Comercial Oasis", new TimeOnly(8, 30, 0) },
                    { 4, "Calle Real 1011", new TimeOnly(21, 30, 0), "Un destino de compras con una amplia variedad de tiendas y servicios", "https://example.com/imagen4.jpg", "Centro Comercial Plaza Real", new TimeOnly(9, 30, 0) },
                    { 5, "Avenida Bella Vista 1213", new TimeOnly(23, 0, 0), "Con una vista panorámica de la ciudad, este centro comercial ofrece una experiencia única de compras", "https://example.com/imagen5.jpg", "Centro Comercial Bella Vista", new TimeOnly(11, 0, 0) }
                });

            migrationBuilder.InsertData(
                schema: "MS",
                table: "Shops",
                columns: new[] { "Id", "Address", "AdminId", "AgentIds", "BannerUrl", "ClosesAt", "Description", "ImageUrl", "MallId", "Name", "OpensAt" },
                values: new object[,]
                {
                    { 1, "Av. Principal 123", 0, null, "https://example.com/la-parrilla.jpg", new TimeOnly(22, 0, 0), "Auténtica comida argentina en el corazón de la ciudad.", "https://example.com/la-parrilla.jpg", 1, "La Parrilla de Juan", new TimeOnly(12, 0, 0) },
                    { 2, "Calle Principal 456", 0, null, "https://example.com/la-parrilla.jpg", new TimeOnly(23, 0, 0), "La mejor pizza al estilo italiano en la ciudad.", "https://example.com/pizzeria-italia.jpg", 1, "Pizzería Italia", new TimeOnly(11, 30, 0) }
                });

            migrationBuilder.InsertData(
                schema: "MS",
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "ShopId" },
                values: new object[,]
                {
                    { 1000, 21, "Corte de carne de vaca asado a la parrilla, jugoso y sabroso.", "https://example.com/bife-de-chorizo.jpg", true, "Bife de Chorizo", 28.99m, 1 },
                    { 1001, 21, "Matambre de cerdo cocido a la parrilla y cubierto con salsa de tomate y queso derretido.", "https://example.com/matambre-a-la-pizza.jpg", true, "Matambre a la Pizza", 22.50m, 1 },
                    { 1002, 21, "Jugosa entraña de vaca asada a la parrilla, tierna y sabrosa.", "https://example.com/entraña-a-la-parrilla.jpg", true, "Entraña a la Parrilla", 30.75m, 1 },
                    { 1003, 21, "Milanesa de carne empanada, cubierta con salsa de tomate, jamón y queso gratinado.", "https://example.com/milanesa-napolitana.jpg", true, "Milanesa Napolitana", 18.99m, 1 },
                    { 1004, 21, "Pan con chorizo criollo a la parrilla, acompañado de chimichurri.", "https://example.com/choripan.jpg", true, "Choripán", 9.50m, 1 },
                    { 1005, 21, "Selección de carnes asadas: vacío, chorizo y morcilla.", "https://example.com/parrillada-mixta.jpg", true, "Parrillada Mixta", 35.99m, 1 },
                    { 1006, 21, "Lomo de vaca asado a la parrilla y cubierto con una exquisita salsa de pimienta.", "https://example.com/lomo-a-la-pimienta.jpg", true, "Lomo a la Pimienta", 32.50m, 1 },
                    { 1007, 21, "Chuletas de cordero marinadas y asadas a la parrilla.", "https://example.com/chuletas-de-cordero.jpg", true, "Chuletas de Cordero", 26.99m, 1 },
                    { 1008, 21, "Costillas de cerdo bañadas en salsa barbacoa y asadas a la parrilla.", "https://example.com/costillas-bbq.jpg", true, "Costillas BBQ", 24.75m, 1 },
                    { 1009, 21, "Solomillo de vaca flambeado al whisky, tierno y lleno de sabor.", "https://example.com/solomillo-al-whisky.jpg", true, "Solomillo al Whisky", 38.50m, 1 },
                    { 2000, 12, "Deliciosa pizza con salsa de tomate, mozzarella y albahaca fresca.", "https://example.com/pizza-margarita.jpg", true, "Pizza Margarita", 12.99m, 2 },
                    { 2001, 12, "Pizza con salsa de tomate, mozzarella y rodajas de pepperoni.", "https://example.com/pizza-pepperoni.jpg", true, "Pizza Pepperoni", 14.50m, 2 },
                    { 2002, 12, "Pizza con salsa de tomate, mozzarella, jamón y piña.", "https://example.com/pizza-hawaiana.jpg", true, "Pizza Hawaiana", 13.75m, 2 },
                    { 2003, 12, "Pizza con salsa barbacoa, pollo, cebolla y mozzarella.", "https://example.com/pizza-bbq.jpg", true, "Pizza BBQ", 16.99m, 2 },
                    { 2004, 12, "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.", "https://example.com/pizza-vegetariana.jpg", true, "Pizza Vegetariana", 15.25m, 2 },
                    { 2005, 12, "Pizza con salsa de tomate, mozzarella, queso azul, queso de cabra y parmesano.", "https://example.com/pizza-cuatro-quesos.jpg", true, "Pizza Cuatro Quesos", 17.50m, 2 },
                    { 2006, 12, "Pizza con salsa de tomate, mozzarella, carne de res, jalapeños y guacamole.", "https://example.com/pizza-mexicana.jpg", true, "Pizza Mexicana", 16.75m, 2 },
                    { 2007, 12, "Pizza con salsa de tomate, mozzarella, tomate fresco y albahaca.", "https://example.com/pizza-caprese.jpg", true, "Pizza Caprese", 15.99m, 2 },
                    { 2008, 12, "Pizza con salsa de tomate, mozzarella, anchoas, aceitunas y alcaparras.", "https://example.com/pizza-siciliana.jpg", true, "Pizza Siciliana", 18.25m, 2 },
                    { 2009, 12, "Pizza cerrada y horneada, rellena de salsa de tomate, mozzarella y jamón.", "https://example.com/pizza-calzone.jpg", true, "Pizza Calzone", 16.50m, 2 },
                    { 2011, 13, "Espaguetis con salsa carbonara, panceta, huevo y queso parmesano.", "https://example.com/espagueti-carbonara.jpg", true, "Espagueti Carbonara", 14.99m, 2 },
                    { 2012, 13, "Fettuccine con una cremosa salsa Alfredo de mantequilla y queso parmesano.", "https://example.com/fettuccine-alfredo.jpg", true, "Fettuccine Alfredo", 16.50m, 2 },
                    { 2013, 13, "Lasaña de carne con salsa de tomate, queso mozzarella y ricotta.", "https://example.com/lasana-clasica.jpg", true, "Lasaña Clásica", 17.25m, 2 },
                    { 2014, 13, "Raviolis rellenos de espinacas y ricotta, servidos con salsa de tomate.", "https://example.com/raviolis-espinacas-ricotta.jpg", true, "Raviolis de Espinacas y Ricotta", 15.75m, 2 },
                    { 2015, 13, "Penne con salsa de tomate picante, ajo y aceite de oliva.", "https://example.com/penne-arrabiata.jpg", true, "Penne Arrabiata", 13.99m, 2 },
                    { 2016, 10, "Pizza con salsa de tomate, mozzarella, champiñones, pimientos y aceitunas.", "https://example.com/pizza-vegetariana.jpg", true, "Pizza Vegetariana", 15.25m, 2 },
                    { 2017, 10, "Espaguetis con una variedad de vegetales de temporada y salsa de tomate.", "https://example.com/espaguetis-primavera.jpg", true, "Espaguetis Primavera", 14.50m, 2 },
                    { 2018, 10, "Ensalada fresca con tomates, mozzarella, albahaca y aderezo balsámico.", "https://example.com/ensalada-caprese.jpg", true, "Ensalada Caprese", 11.99m, 2 },
                    { 2019, 10, "Hamburguesa vegana hecha con frijoles negros, quinoa y vegetales, servida con papas fritas.", "https://example.com/hamburguesa-vegetariana.jpg", true, "Hamburguesa Vegetariana", 13.75m, 2 },
                    { 2020, 10, "Wrap relleno de falafel, hummus, verduras frescas y salsa tahini.", "https://example.com/wrap-falafel.jpg", true, "Wrap de Falafel", 12.50m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                schema: "MS",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                schema: "MS",
                table: "Items",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_ItemId",
                schema: "MS",
                table: "Promotion",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_ShopId",
                schema: "MS",
                table: "Promotion",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_MallId",
                schema: "MS",
                table: "Shops",
                column: "MallId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotion",
                schema: "MS");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "MS");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "MS");

            migrationBuilder.DropTable(
                name: "Shops",
                schema: "MS");

            migrationBuilder.DropTable(
                name: "Malls",
                schema: "MS");
        }
    }
}
