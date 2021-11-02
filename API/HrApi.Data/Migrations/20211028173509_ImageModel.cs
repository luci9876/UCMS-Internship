using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class ImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a17018b-b1e2-4616-a136-e969dc793d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce8974ac-738b-4502-a010-68b484de6478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef38b30a-8c6c-471f-b917-e3fbb4e41b2c");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ac2c727-037a-4997-93bb-4ad350512b5d", "22a91750-4890-48e2-b637-945f95646401", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d962308a-1da9-4c42-9b62-a9f0073067cd", "f7160a88-bb2f-42ae-9b23-a36e4557dba4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "778bea51-932b-4d04-acf2-d2da87f3e68d", "8f7ffdad-fbc6-439d-bff3-a6d42a4165ac", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac2c727-037a-4997-93bb-4ad350512b5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "778bea51-932b-4d04-acf2-d2da87f3e68d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d962308a-1da9-4c42-9b62-a9f0073067cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce8974ac-738b-4502-a010-68b484de6478", "5b0aec78-37c8-42c5-99bf-de887629e2ea", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a17018b-b1e2-4616-a136-e969dc793d60", "951afa47-802c-4e03-b502-a2f7a6dc3ae8", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef38b30a-8c6c-471f-b917-e3fbb4e41b2c", "1aaf9d33-dd82-4927-8ede-6cbb26d55c56", "Administrator", "ADMINISTRATOR" });
        }
    }
}
