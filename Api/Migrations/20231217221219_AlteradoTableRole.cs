using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoTableRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Role",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);
        }
    }
}
