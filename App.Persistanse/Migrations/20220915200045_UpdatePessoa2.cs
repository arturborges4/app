using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistense.Migrations
{
    public partial class UpdatePessoa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cidades",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cidades",
                newName: "id");
        }
    }
}
