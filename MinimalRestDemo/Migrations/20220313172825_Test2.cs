using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalRestDemo.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UserCourses_UserCourseId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCourses_UserCourseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCourseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserCourseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserCourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCourseId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => new { x.CoursesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_UsersId",
                table: "UserCourse",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.AddColumn<int>(
                name: "UserCourseId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCourseId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCourseId",
                table: "Users",
                column: "UserCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserCourseId",
                table: "Courses",
                column: "UserCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UserCourses_UserCourseId",
                table: "Courses",
                column: "UserCourseId",
                principalTable: "UserCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCourses_UserCourseId",
                table: "Users",
                column: "UserCourseId",
                principalTable: "UserCourses",
                principalColumn: "Id");
        }
    }
}
