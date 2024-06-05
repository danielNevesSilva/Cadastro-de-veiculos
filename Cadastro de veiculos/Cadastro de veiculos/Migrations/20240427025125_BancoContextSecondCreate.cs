using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro_de_veiculos.Migrations
{
    /// <inheritdoc />
    public partial class BancoContextSecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Renavam",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Renavam",
                table: "veiculos");
        }
    }
}
