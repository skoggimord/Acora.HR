using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acora.HR.UI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0c6de67f-b6d5-4e61-ad6f-0c49583599bd"), "QA" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"), "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("bbd65116-a83e-49ae-a074-e57cf341c568"), "IT" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "Address", "City", "DateOfBirth", "DepartmentId", "Firstname", "Lastname" },
                values: new object[] { 1, "1 Top Street", "Manchester", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"), "TestA", "TestALastname" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "Address", "City", "DateOfBirth", "DepartmentId", "Firstname", "Lastname" },
                values: new object[] { 2, "1 Left Street", "Liverpool", new DateTime(1989, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"), "TestB", "TestBLastname" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "Address", "City", "DateOfBirth", "DepartmentId", "Firstname", "Lastname" },
                values: new object[] { 3, "1 Top Street", "London", new DateTime(1972, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"), "TestC", "TestCLastname" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
