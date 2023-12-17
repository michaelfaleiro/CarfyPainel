using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoCampoPreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoVenda",
                table: "Produto",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoCusto",
                table: "Produto",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoVenda",
                table: "Produto",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoCusto",
                table: "Produto",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");
        }
    }
}