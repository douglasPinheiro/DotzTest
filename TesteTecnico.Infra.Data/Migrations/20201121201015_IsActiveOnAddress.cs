using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.Infra.Data.Migrations
{
    public partial class IsActiveOnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 21, 17, 10, 15, 23, DateTimeKind.Local).AddTicks(9558),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Address",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Address",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 21, 17, 10, 15, 23, DateTimeKind.Local).AddTicks(9558));
        }
    }
}
