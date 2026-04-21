using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeMVC_DB_Identitty.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Cour_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cour_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cour_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cour_Cont = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cour_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Cour_Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    stu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stu_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stu_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stu_Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<DateOnly>(type: "date", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.stu_Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Cour_Id");
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    rec_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stu_Id = table.Column<int>(type: "int", nullable: false),
                    Studentstu_Id = table.Column<int>(type: "int", nullable: false),
                    f_date = table.Column<DateOnly>(type: "date", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.rec_Id);
                    table.ForeignKey(
                        name: "FK_Fees_Students_Studentstu_Id",
                        column: x => x.Studentstu_Id,
                        principalTable: "Students",
                        principalColumn: "stu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fees_Studentstu_Id",
                table: "Fees",
                column: "Studentstu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
