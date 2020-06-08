using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace User.IO.Rommanel.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rommanel");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Rommanel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateBirth = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(150)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    State = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Rommanel");
        }
    }
}
