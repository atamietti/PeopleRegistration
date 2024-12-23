using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleRegistration.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "isPrimary",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Phone",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPrimary",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
