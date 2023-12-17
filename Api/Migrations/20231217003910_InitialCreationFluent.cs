using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreationFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cliente = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Veiculo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Placa = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: true),
                    Chassi = table.Column<string>(type: "VARCHAR(17)", maxLength: 17, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    Sku = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    NomeProduto = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    PrecoCusto = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "DECIMAL(38,17)", nullable: false),
                    Link = table.Column<string>(type: "NVARCHAR", nullable: true),
                    Observacao = table.Column<string>(type: "NVARCHAR", nullable: true),
                    OrcamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Orcamento",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_Cliente",
                table: "Orcamento",
                column: "Cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrcamentoId",
                table: "Produto",
                column: "OrcamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Orcamento");
        }
    }
}