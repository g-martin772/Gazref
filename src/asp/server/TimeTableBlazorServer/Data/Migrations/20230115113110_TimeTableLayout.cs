using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableBlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class TimeTableLayout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Teachers",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                newName: "IX_Teachers_LessonId");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    InternPublic = table.Column<bool>(type: "bit", nullable: false),
                    OrganisationMemberMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TimeTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_LessonId",
                table: "Students",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_MemberId",
                table: "Classes",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TimeTableId",
                table: "Lessons",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_OrganisationMemberMemberId",
                table: "TimeTables",
                column: "OrganisationMemberMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes",
                column: "MemberId",
                principalTable: "Teachers",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lessons_LessonId",
                table: "Students",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_MemberId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lessons_LessonId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Lessons_LessonId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_Students_LessonId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classes_MemberId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Teachers",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_LessonId",
                table: "Teachers",
                newName: "IX_Teachers_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
