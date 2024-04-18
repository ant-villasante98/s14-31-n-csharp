using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S14.Migrations.PaymentsSystem
{
    /// <inheritdoc />
    public partial class payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PS");

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "PS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentError",
                schema: "PS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentError_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "PS",
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentError_PaymentId",
                schema: "PS",
                table: "PaymentError",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentError",
                schema: "PS");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "PS");
        }
    }
}
