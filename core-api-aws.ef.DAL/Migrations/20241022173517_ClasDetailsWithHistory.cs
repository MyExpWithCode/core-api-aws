using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace core_api_aws.ef.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ClasDetailsWithHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                schema: "sample_poc",
                table: "Students",
                newName: "ClassId");

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "sample_poc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassesHistory",
                schema: "sample_poc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    PassPercentage = table.Column<double>(type: "double precision", nullable: false),
                    MaxPercentage = table.Column<double>(type: "double precision", nullable: false),
                    TeacherName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes",
                schema: "sample_poc");

            migrationBuilder.DropTable(
                name: "ClassesHistory",
                schema: "sample_poc");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                schema: "sample_poc",
                table: "Students",
                newName: "Class");
        }
    }
}
