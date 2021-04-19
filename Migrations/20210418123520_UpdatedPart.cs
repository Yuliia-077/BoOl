using Microsoft.EntityFrameworkCore.Migrations;

namespace BoOl.Migrations
{
    public partial class UpdatedPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices");

            migrationBuilder.DropIndex(
                name: "IX_CustomServices_PartId",
                table: "CustomServices");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "CustomServices");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Parts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomServiceId",
                table: "Parts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsInjured",
                table: "Parts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CustomServiceId",
                table: "Parts",
                column: "CustomServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_CustomServices_CustomServiceId",
                table: "Parts",
                column: "CustomServiceId",
                principalTable: "CustomServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_CustomServices_CustomServiceId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CustomServiceId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CustomServiceId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsInjured",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Parts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "CustomServices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomServices_PartId",
                table: "CustomServices",
                column: "PartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
