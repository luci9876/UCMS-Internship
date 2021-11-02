using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class ChangeEmployeeStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company_Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18f2d8c0-1c43-4652-be4a-a5e3877fcf3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a2b790-d705-4a88-bb48-ef8eefda4611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f434064b-0e87-4512-b6b9-9a49a2ac22a1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_CompanyId",
                table: "CompanyEmployee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeeId",
                table: "CompanyEmployee",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyEmployee");

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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Company_Employee",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Company_Employee_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Employee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18f2d8c0-1c43-4652-be4a-a5e3877fcf3d", "17eb559f-3179-43c3-83ed-5ab2620e69f5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f434064b-0e87-4512-b6b9-9a49a2ac22a1", "23ca565d-6aa9-4a7b-8de7-b8630639f06b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95a2b790-d705-4a88-bb48-ef8eefda4611", "06a7d10d-4707-4f40-95c6-936343308c7e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Employee_CompanyId",
                table: "Company_Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Employee_EmployeeId",
                table: "Company_Employee",
                column: "EmployeeId");
        }
    }
}
