using Microsoft.EntityFrameworkCore.Migrations;

namespace BoOl.Migrations
{
    public partial class CustomServiceAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "CustomServices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Workers",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "CustomServices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
