using Microsoft.EntityFrameworkCore.Migrations;

namespace AIR_RESERVATION_SYSTEM_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminDetails",
                columns: table => new
                {
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FlightMaster",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightMaster", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "FlightsDetails",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1001, 1"),
                    DestinationFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArriveTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightClass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsDetails", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    confirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_emailId",
                table: "UserDetails",
                column: "emailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDetails");

            migrationBuilder.DropTable(
                name: "FlightMaster");

            migrationBuilder.DropTable(
                name: "FlightsDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
