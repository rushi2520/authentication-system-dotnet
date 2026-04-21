using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeMVC_DB_Identitty.Migrations
{
    /// <inheritdoc />
    public partial class InitialBusinessData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Students_Studentstu_Id",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fees",
                table: "Fees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Fees",
                newName: "Feess");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Coursess");

            migrationBuilder.RenameIndex(
                name: "IX_Fees_Studentstu_Id",
                table: "Feess",
                newName: "IX_Feess_Studentstu_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feess",
                table: "Feess",
                column: "rec_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coursess",
                table: "Coursess",
                column: "Cour_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feess_Students_Studentstu_Id",
                table: "Feess",
                column: "Studentstu_Id",
                principalTable: "Students",
                principalColumn: "stu_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coursess_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Coursess",
                principalColumn: "Cour_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feess_Students_Studentstu_Id",
                table: "Feess");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coursess_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feess",
                table: "Feess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coursess",
                table: "Coursess");

            migrationBuilder.RenameTable(
                name: "Feess",
                newName: "Fees");

            migrationBuilder.RenameTable(
                name: "Coursess",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Feess_Studentstu_Id",
                table: "Fees",
                newName: "IX_Fees_Studentstu_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fees",
                table: "Fees",
                column: "rec_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Cour_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Students_Studentstu_Id",
                table: "Fees",
                column: "Studentstu_Id",
                principalTable: "Students",
                principalColumn: "stu_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Cour_Id");
        }
    }
}
