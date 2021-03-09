using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApiBook.Migrations
{
    public partial class db_contactUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Contacts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Update",
                table: "Contacts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Date_Update",
                table: "Contacts");
        }
    }
}
