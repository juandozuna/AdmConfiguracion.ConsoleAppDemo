using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfigManagementDemo.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationItems",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItems", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DependencyItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseCiName = table.Column<string>(nullable: true),
                    DependencyCiName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependencyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependencyItems_ConfigurationItems_BaseCiName",
                        column: x => x.BaseCiName,
                        principalTable: "ConfigurationItems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DependencyItems_ConfigurationItems_DependencyCiName",
                        column: x => x.DependencyCiName,
                        principalTable: "ConfigurationItems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependencyItems_BaseCiName",
                table: "DependencyItems",
                column: "BaseCiName");

            migrationBuilder.CreateIndex(
                name: "IX_DependencyItems_DependencyCiName",
                table: "DependencyItems",
                column: "DependencyCiName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependencyItems");

            migrationBuilder.DropTable(
                name: "ConfigurationItems");
        }
    }
}
