using Microsoft.EntityFrameworkCore.Migrations;

namespace Bglobal.Migrations
{
    public partial class FixBDDMigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Titulares_TitularId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Titulares_TitularId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_TitularId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "TitularVehiculoId",
                table: "Emails");

            migrationBuilder.AlterColumn<int>(
                name: "TitularId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Titulares_TitularId",
                table: "Emails",
                column: "TitularId",
                principalTable: "Titulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Titulares_TitularId",
                table: "Emails");

            migrationBuilder.AddColumn<int>(
                name: "TitularId",
                table: "Vehiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TitularId",
                table: "Emails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TitularVehiculoId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TitularId",
                table: "Vehiculos",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Titulares_TitularId",
                table: "Emails",
                column: "TitularId",
                principalTable: "Titulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Titulares_TitularId",
                table: "Vehiculos",
                column: "TitularId",
                principalTable: "Titulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
