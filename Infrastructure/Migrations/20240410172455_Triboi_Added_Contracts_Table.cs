using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Triboi_Added_Contracts_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifierUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeleterUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02ccf5fd-ce71-45a7-a373-ea49c807d67b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ff05e90-3db8-4b2a-81de-5eb4c44c1fd0", "AKqrBiPKgdhrsOSm77wtAMbizg87oITURtWIPFCIyy0daBPwwM0yTr5sM8VW2UvRHQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02ccf5fd-ce71-45a7-a373-ea49c807d67b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3dbf6d9-8cd3-4948-b747-8273cf7a0334", "AHKPa+tRjGThSTvMps93JfKEkj5Qyh1aS6TxtJ/R6vYmQpLRAN0kQOk3Nea9ilr02g==" });
        }
    }
}
