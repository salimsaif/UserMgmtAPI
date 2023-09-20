using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMgmt.Migrations
{
    /// <inheritdoc />
    public partial class user1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediclaimType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediclaimType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasMediclaim = table.Column<bool>(type: "bit", nullable: true),
                    MediclaimTypeId = table.Column<int>(type: "int", nullable: true),
                    UsersInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSalary_MediclaimType_MediclaimTypeId",
                        column: x => x.MediclaimTypeId,
                        principalTable: "MediclaimType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSalary_UsersInfo_UsersInfosId",
                        column: x => x.UsersInfosId,
                        principalTable: "UsersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSalary_MediclaimTypeId",
                table: "UserSalary",
                column: "MediclaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSalary_UsersInfosId",
                table: "UserSalary",
                column: "UsersInfosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSalary");

            migrationBuilder.DropTable(
                name: "MediclaimType");

            migrationBuilder.DropTable(
                name: "UsersInfo");
        }
    }
}
