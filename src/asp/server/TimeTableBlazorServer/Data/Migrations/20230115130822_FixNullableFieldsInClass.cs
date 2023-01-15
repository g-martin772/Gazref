using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableBlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixNullableFieldsInClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Classes_MemberId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_MemberId",
                table: "Classes",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes",
                column: "MemberId",
                principalTable: "Teachers",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Classes_MemberId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_MemberId",
                table: "Classes",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes",
                column: "MemberId",
                principalTable: "Teachers",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
