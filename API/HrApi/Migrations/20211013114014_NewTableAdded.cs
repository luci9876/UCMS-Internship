using Microsoft.EntityFrameworkCore.Migrations;

namespace HrApi.Migrations
{
    public partial class NewTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Company_Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_id = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Employee", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Company_Employee_Company_Employeeid",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_Employee_Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Company_Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Company_Employeeid",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Company_Employeeid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Company_Employeeid",
                table: "Companies");
        }
    }
}
