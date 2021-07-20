using Microsoft.EntityFrameworkCore.Migrations;

namespace Bglobal.Migrations
{
    public partial class FixBDDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "TitularId",
                table: "Vehiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TitularId",
                table: "Vehiculos",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Titulares_TitularId",
                table: "Vehiculos",
                column: "TitularId",
                principalTable: "Titulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Titulares_TitularId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_TitularId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Vehiculos");

            
        }
    }
}
