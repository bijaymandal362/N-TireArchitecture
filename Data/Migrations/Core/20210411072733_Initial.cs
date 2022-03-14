using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations.Core
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListItemCategory",
                columns: table => new
                {
                    ListItemCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListItemCategoryName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ListItemCategorySystemName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsSystemConfig = table.Column<bool>(type: "INTEGER", nullable: false),
                    InsertPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatePersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItemCategory", x => x.ListItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    InsertPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatePersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    ListItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListItemCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListItemName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ListItemSystemName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsSystemConfig = table.Column<bool>(type: "INTEGER", nullable: false),
                    InsertPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatePersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.ListItemId);
                    table.ForeignKey(
                        name: "FK_ListItem_ListItemCategory_ListItemCategoryId",
                        column: x => x.ListItemCategoryId,
                        principalTable: "ListItemCategory",
                        principalColumn: "ListItemCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListItemCategoryId_ListItemName",
                table: "ListItem",
                columns: new[] { "ListItemCategoryId", "ListItemName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListItemSystemName",
                table: "ListItem",
                column: "ListItemSystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItemCategory_ListItemCategorySystemName",
                table: "ListItemCategory",
                column: "ListItemCategorySystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ListItemCategory");
        }
    }
}
