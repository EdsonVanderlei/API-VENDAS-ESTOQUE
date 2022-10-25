using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCarros.Migrations
{
    public partial class TabelaVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrosVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Placa = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrosVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrosVendidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrosVendidos_ClienteId",
                table: "CarrosVendidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrosVendidos_Placa",
                table: "CarrosVendidos",
                column: "Placa",
                unique: true,
                filter: "[Placa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrosVendidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
