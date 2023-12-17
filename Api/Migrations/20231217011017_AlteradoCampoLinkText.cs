using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoCampoLinkText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoVenda",
                table: "Produto",
                type: "DECIMAL(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoCusto",
                table: "Produto",
                type: "DECIMAL(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Produto",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Produto",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)",
                oldNullable: true);
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
                oldType: "DECIMAL(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoCusto",
                table: "Produto",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(38,17)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Produto",
                type: "NVARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Produto",
                type: "NVARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
