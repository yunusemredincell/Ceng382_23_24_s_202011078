using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YedWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnecessaryColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reservations");
            migrationBuilder.DropColumn(
            name: "Date",
            table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        migrationBuilder.AddColumn<DateTime>(
            name: "Time",
            table: "Reservations",
            type: "datetime2",
            nullable: false,
            defaultValue: DateTime.Now);

        migrationBuilder.AddColumn<DateTime>(
            name: "Date",
            table: "Reservations",
            type: "datetime2",
            nullable: false,
            defaultValue: DateTime.Now); 
        }
    }
}
