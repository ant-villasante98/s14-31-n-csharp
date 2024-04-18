using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S14.Migrations.QrSystem
{
    /// <inheritdoc />
    public partial class QR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QR");

            migrationBuilder.CreateTable(
                name: "Qrs",
                schema: "QR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SvgValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qrs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qrs",
                schema: "QR");
        }
    }
}
