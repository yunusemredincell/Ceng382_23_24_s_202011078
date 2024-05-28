using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YedWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservationSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddColumn<DateTime>(
            name: "ReservationEndDate",
            table: "Reservations",
            nullable: false,
            defaultValue: new DateTime(0));

        migrationBuilder.AddColumn<DateTime>(
            name: "ReservationStartDate",
            table: "Reservations",
            nullable: false,
            defaultValue: new DateTime(0));

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
            name: "ReservationEndDate",
            table: "Reservations");

        migrationBuilder.DropColumn(
            name: "ReservationStartDate",
            table: "Reservations");

        }
    }
}
