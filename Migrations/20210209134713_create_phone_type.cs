using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApiBook.Migrations
{
    public partial class create_phone_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Phone_typeId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Phone_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Phone_typeId",
                table: "Phones",
                column: "Phone_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Phone_Types_Phone_typeId",
                table: "Phones",
                column: "Phone_typeId",
                principalTable: "Phone_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Phone_Types_Phone_typeId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Phone_Types");

            migrationBuilder.DropIndex(
                name: "IX_Phones_Phone_typeId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Phone_typeId",
                table: "Phones");
        }
    }
}
