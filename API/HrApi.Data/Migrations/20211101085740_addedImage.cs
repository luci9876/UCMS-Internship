using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class addedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91c79490-7f54-4e92-85b5-5f3733f17bd9", "74c3e829-5c31-44b6-861d-92d9c1be5d05", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b96439ae-9238-476a-ab4c-5d4a10583143", "184978d6-555e-48bd-9aae-9d38d61c967c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03ac84b6-c933-4470-a040-88bcaf575af9", "5c2df4c6-a33d-4441-bbf4-fdfb350e68d9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ImageId",
                table: "Employees",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Images_ImageId",
                table: "Employees",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Images_ImageId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ImageId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ac84b6-c933-4470-a040-88bcaf575af9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c79490-7f54-4e92-85b5-5f3733f17bd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b96439ae-9238-476a-ab4c-5d4a10583143");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Employees");

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
    }
}
