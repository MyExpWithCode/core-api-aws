using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_api_aws.ef.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ClassWithForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassId",
                schema: "sample_poc",
                table: "Students",
                newName: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClassId",
                schema: "sample_poc",
                table: "Students",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_StudentClassId",
                schema: "sample_poc",
                table: "Students",
                column: "StudentClassId",
                principalSchema: "sample_poc",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_StudentClassId",
                schema: "sample_poc",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentClassId",
                schema: "sample_poc",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentClassId",
                schema: "sample_poc",
                table: "Students",
                newName: "ClassId");
        }
    }
}
