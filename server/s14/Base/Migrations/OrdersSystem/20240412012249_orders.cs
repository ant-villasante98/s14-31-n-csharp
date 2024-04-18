using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S14.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OS");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "OS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "OS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "OS",
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryStates",
                schema: "OS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryStates_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "OS",
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_OrderId",
                schema: "OS",
                table: "Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryStates_OrderId",
                schema: "OS",
                table: "HistoryStates",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details",
                schema: "OS");

            migrationBuilder.DropTable(
                name: "HistoryStates",
                schema: "OS");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "OS");
        }
    }
}
