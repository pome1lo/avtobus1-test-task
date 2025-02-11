using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShortLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortUrl = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortLinks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ShortLinks",
                columns: new[] { "Id", "ClickCount", "CreatedAt", "OriginalUrl", "ShortUrl" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 2, 11, 15, 51, 58, 228, DateTimeKind.Utc).AddTicks(6950), "https://blogs-images.forbes.com/ceciliarodriguez/files/2018/06/00000015_p.jpg", "ad8f56e6" },
                    { 2, 0, new DateTime(2025, 2, 11, 15, 51, 58, 228, DateTimeKind.Utc).AddTicks(6961), "https://s0.rbk.ru/v6_top_pics/media/img/5/13/756372136012135.jpg", "2677ccea" },
                    { 3, 0, new DateTime(2025, 2, 11, 15, 51, 58, 228, DateTimeKind.Utc).AddTicks(6979), "https://i.pinimg.com/736x/38/1e/0f/381e0f5a84c95c81f2d470d71ee9c2b4.jpg", "c2c59d47" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortLinks_ShortUrl",
                table: "ShortLinks",
                column: "ShortUrl",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortLinks");
        }
    }
}
