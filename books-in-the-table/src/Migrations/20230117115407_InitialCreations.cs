using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace booksinthetable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: false),
                    nationality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "author_publisher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(name: "author_id", type: "uuid", nullable: false),
                    publisherid = table.Column<Guid>(name: "publisher_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_publisher", x => x.id);
                    table.ForeignKey(
                        name: "FK_author_publisher_author_author_id",
                        column: x => x.authorid,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_publisher_publisher_publisher_id",
                        column: x => x.publisherid,
                        principalTable: "publisher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    isbn13 = table.Column<string>(type: "text", nullable: false),
                    isbn10 = table.Column<string>(type: "text", nullable: false),
                    releaseyear = table.Column<string>(name: "release_year", type: "text", nullable: false),
                    numberpages = table.Column<int>(name: "number_pages", type: "integer", nullable: false),
                    language = table.Column<string>(type: "text", nullable: true),
                    authorid = table.Column<Guid>(name: "author_id", type: "uuid", nullable: false),
                    publisherid = table.Column<Guid>(name: "publisher_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                    table.ForeignKey(
                        name: "FK_book_author_author_id",
                        column: x => x.authorid,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_publisher_publisher_id",
                        column: x => x.publisherid,
                        principalTable: "publisher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_publisher_author_id",
                table: "author_publisher",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_author_publisher_publisher_id",
                table: "author_publisher",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_publisher_id",
                table: "book",
                column: "publisher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_publisher");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
