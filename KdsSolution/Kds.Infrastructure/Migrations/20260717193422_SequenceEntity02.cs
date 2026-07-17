using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SequenceEntity02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "sequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SequenceId",
                table: "sequence",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
