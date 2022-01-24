using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TrainMonitor.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrigadeId",
                table: "employee",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "brigade",
                columns: table => new
                {
                    Id_Brigade = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrigadeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brigade", x => x.Id_Brigade);
                });

            migrationBuilder.InsertData(
                table: "brigade",
                columns: new[] { "Id_Brigade", "BrigadeName" },
                values: new object[] { 1, "Пусто" });

            migrationBuilder.CreateIndex(
                name: "IX_employee_BrigadeId",
                table: "employee",
                column: "BrigadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_brigade_BrigadeId",
                table: "employee",
                column: "BrigadeId",
                principalTable: "brigade",
                principalColumn: "Id_Brigade",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_brigade_BrigadeId",
                table: "employee");

            migrationBuilder.DropTable(
                name: "brigade");

            migrationBuilder.DropIndex(
                name: "IX_employee_BrigadeId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "BrigadeId",
                table: "employee");
        }
    }
}
