using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "menu_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menu_item_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    table_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order_type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.order_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "kot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    kot_no = table.Column<long>(type: "bigint", nullable: false),
                    is_kot_printed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    kot_printed_on = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    is_cancel_kot_printed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cancelled_kot_printed_on = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    kot_preparation_started_on = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    kot_ready_on = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    kot_cancelled_on = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    kot_completed_on = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_kot_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    kot_id = table.Column<long>(type: "bigint", nullable: false),
                    menu_item_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    remarks = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_on = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    cancelled_on = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_item_kot_kot_id",
                        column: x => x.kot_id,
                        principalTable: "kot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_item_menu_item_menu_item_id",
                        column: x => x.menu_item_id,
                        principalTable: "menu_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_kot_order_id",
                table: "kot",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_kot_id",
                table: "order_item",
                column: "kot_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_menu_item_id",
                table: "order_item",
                column: "menu_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id",
                table: "order_item",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "kot");

            migrationBuilder.DropTable(
                name: "menu_item");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
