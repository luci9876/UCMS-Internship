using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class ChangeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Company_Employee_Company_Employeeid",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_Employee_Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Company_Employeeid",
                table: "Companies");

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
                name: "Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Company_Employeeid",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38e7f966-db02-4208-8b55-a7149dd6faf8", "8af651a0-1745-4def-9135-b1a2044c95eb", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7d07b4a-57e8-49ff-ab54-04c89dfd1ee9", "e8fe48f7-fded-4e0a-9281-559a86b3cfa0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0099e40a-4160-4fd5-864a-b1dff0895748", "71f2044d-f36b-4db4-a2b9-b51983ea6af7", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0099e40a-4160-4fd5-864a-b1dff0895748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38e7f966-db02-4208-8b55-a7149dd6faf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d07b4a-57e8-49ff-ab54-04c89dfd1ee9");

            migrationBuilder.AddColumn<int>(
                name: "Company_Employeeid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company_Employeeid",
                table: "Companies",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Company_Employeeid",
                table: "Employees",
                column: "Company_Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Company_Employeeid",
                table: "Companies",
                column: "Company_Employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Company_Employee_Company_Employeeid",
                table: "Companies",
                column: "Company_Employeeid",
                principalTable: "Company_Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Company_Employee_Company_Employeeid",
                table: "Employees",
                column: "Company_Employeeid",
                principalTable: "Company_Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
