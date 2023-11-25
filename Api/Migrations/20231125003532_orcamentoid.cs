using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class orcamentoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrcamentoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrcamentoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id");
        }
    }
}
