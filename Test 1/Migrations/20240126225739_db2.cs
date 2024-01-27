using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_1.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "lostPerson");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "foundPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "lostPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "foundPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
