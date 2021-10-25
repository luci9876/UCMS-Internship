using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class AddedFoundingYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c696c85-fce4-4236-9e32-066c175197a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8023efca-4cef-414a-8f6a-4dd1b3583c46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9857653b-c218-4cb9-bdb7-7c65ff97d7c1");

            migrationBuilder.AddColumn<int>(
                name: "Founded",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f41e1fa-da5a-49b1-97e0-3757afa55b07", "7c047840-a55e-4af2-9d7b-541f31f53635", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ff3ab18-5963-4239-b764-376dc00d8539", "0d68aa6e-def1-43d8-b0d5-6332660b5e6f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7056dfe-4da8-42c0-8f9c-c11f00a4d63e", "bfeb16ae-7893-4a08-b88f-08c3f7409595", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff3ab18-5963-4239-b764-376dc00d8539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f41e1fa-da5a-49b1-97e0-3757afa55b07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7056dfe-4da8-42c0-8f9c-c11f00a4d63e");

            migrationBuilder.DropColumn(
                name: "Founded",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c696c85-fce4-4236-9e32-066c175197a8", "ff87fde9-f5fc-4ff5-afcc-570cad0c3ac8", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8023efca-4cef-414a-8f6a-4dd1b3583c46", "6a0e0009-a33e-4bad-bdec-7dae1f89ab1b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9857653b-c218-4cb9-bdb7-7c65ff97d7c1", "56cd6a5e-3618-40e3-8781-cd17998c7e5a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
