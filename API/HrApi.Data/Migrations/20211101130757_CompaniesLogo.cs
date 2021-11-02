using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class CompaniesLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9757e4ba-2ddc-4c47-93db-5271edf2ddad", "d93cf078-c44a-4625-a06a-693d9688a7a9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f34e3d08-6ece-4a2b-99dc-7cef86046089", "bc5f102e-635d-439a-91f8-529971c08634", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb4b65fe-691e-40f7-a5b2-5e503cae3b17", "5162e2ec-014f-4632-afa8-e33a385b3f9c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ImageId",
                table: "Companies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ImageId",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9757e4ba-2ddc-4c47-93db-5271edf2ddad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f34e3d08-6ece-4a2b-99dc-7cef86046089");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb4b65fe-691e-40f7-a5b2-5e503cae3b17");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Companies");

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
        }
    }
}
