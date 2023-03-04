using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace phonebook_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialphonebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "phonebook_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "PhoneBookEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBookEntry", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBookEntry");

            migrationBuilder.DropSequence(
                name: "phonebook_hilo");
        }
    }
}
