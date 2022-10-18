using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.MVC.Data.Migrations
{
    public partial class ForeignKeyFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleMakes_MakeId",
                table: "VehicleModels",
                column: "MakeId",
                principalTable: "VehicleMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleMakes_MakeId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels");

            migrationBuilder.AddColumn<int>(
                name: "VehicleMakeId",
                table: "VehicleModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId",
                principalTable: "VehicleMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
