using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_software_documentation.Migrations
{
    /// <inheritdoc />
    public partial class UserRequirementsFunctionalRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunctionalRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Sequential = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Actor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionalRequirements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Sequential = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequirements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FunctionalRequirements_UserRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FunctionalRequirementId = table.Column<int>(type: "int", nullable: false),
                    UserRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRequirements_UserRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionalRequirements_UserRequirements_FunctionalRequiremen~",
                        column: x => x.FunctionalRequirementId,
                        principalTable: "FunctionalRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionalRequirements_UserRequirements_UserRequirements_Use~",
                        column: x => x.UserRequirementId,
                        principalTable: "UserRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCharters_ProjectId",
                table: "ProjectCharters",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalRequirements_ProjectId",
                table: "FunctionalRequirements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalRequirements_UserRequirements_FunctionalRequiremen~",
                table: "FunctionalRequirements_UserRequirements",
                column: "FunctionalRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalRequirements_UserRequirements_UserRequirementId",
                table: "FunctionalRequirements_UserRequirements",
                column: "UserRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequirements_ProjectId",
                table: "UserRequirements",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionalRequirements_UserRequirements");

            migrationBuilder.DropTable(
                name: "FunctionalRequirements");

            migrationBuilder.DropTable(
                name: "UserRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCharters",
                table: "ProjectCharters");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCharters_ProjectId",
                table: "ProjectCharters");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProjectCharters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
