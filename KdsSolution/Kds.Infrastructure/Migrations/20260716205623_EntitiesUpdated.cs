using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_type",
                table: "order");

            migrationBuilder.DropColumn(
                name: "cancelled_kot_printed_on",
                table: "kot");

            migrationBuilder.DropColumn(
                name: "is_cancel_kot_printed",
                table: "kot");

            migrationBuilder.DropColumn(
                name: "is_kot_printed",
                table: "kot");

            migrationBuilder.DropColumn(
                name: "kot_printed_on",
                table: "kot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_type",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "cancelled_kot_printed_on",
                table: "kot",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_cancel_kot_printed",
                table: "kot",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_kot_printed",
                table: "kot",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "kot_printed_on",
                table: "kot",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
