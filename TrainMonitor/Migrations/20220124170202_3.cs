using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainMonitor.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "employee",
                nullable: true);

          

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "ID_Employee",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "ID_Post",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "ID_Department",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "employee");

            migrationBuilder.UpdateData(
                table: "department",
                keyColumn: "ID_Department",
                keyValue: 1,
                column: "DepartmentName",
                value: "Администратор");

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "ID_Department", "DepartmentName" },
                values: new object[] { -1, "Пусто" });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "ID_Employee", "Birth_Date", "Email", "Login", "Name", "Passport_Number", "Passport_Series", "Password", "Patronymic", "PostId", "Surname" },
                values: new object[] { 1, new DateTime(1997, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "mistred24@yandex.ru", "Admin", "Admin", "000000", "0000", "Admin", "Admin", 1, "Admin" });

            migrationBuilder.UpdateData(
                table: "post",
                keyColumn: "ID_Post",
                keyValue: 1,
                column: "PostName",
                value: "Администратор");

            migrationBuilder.InsertData(
                table: "post",
                columns: new[] { "ID_Post", "DepartmentId", "PostName", "Salary" },
                values: new object[] { -1, -1, "Пусто", 0 });
        }
    }
}
