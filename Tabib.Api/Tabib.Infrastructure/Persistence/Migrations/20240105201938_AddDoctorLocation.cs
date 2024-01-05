using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabib.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Doctor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_LocationId",
                table: "Doctor",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Location_LocationId",
                table: "Doctor",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Location_LocationId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_LocationId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Doctor");
        }
    }
}
