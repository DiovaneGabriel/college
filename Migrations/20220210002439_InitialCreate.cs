using System;
using System.Collections.Generic;
using College.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace College.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subject_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SubjectID",
                table: "Enrollment",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_TeacherID",
                table: "Enrollment",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseID",
                table: "Subject",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherID",
                table: "Subject",
                column: "TeacherID");

            this.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
        protected void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Student", columns: new[] { "ID","Name", "Birthday" }, values: new object[,]
            {
                {65484,"Diovane Barbieri Gabriel", DateTime.Parse("1992-05-01") },
                {65284,"Julio Vinicius Ramos", DateTime.Parse("1994-02-04") },
                {65483,"Flávia Raquel Pinto", DateTime.Parse("2003-01-22") },
                {65481,"Iago Henrique da Silva", DateTime.Parse("1984-08-18") },
                {78484,"Adriana Juliana Bernardes", DateTime.Parse("2004-07-15") },
                {65984,"Thales Caleb Enrico Almeida", DateTime.Parse("1981-10-04") },
                {99484,"Rita Jennifer Rocha", DateTime.Parse("1996-03-10") }
            });

            migrationBuilder.InsertData(table: "Teacher", columns: new[] { "ID", "Name", "Birthday", "Salary" }, values: new object[,]
            {
                {852,"Gabriela Carla Nascimento", DateTime.Parse("1957-01-06"),3000.00 },
                {159,"Nicole Emanuelly Moreira", DateTime.Parse("1946-08-30"),3000.00 },
                {356,"Renan Bernardo Carvalho", DateTime.Parse("1987-01-31"),3000.00 }
            });

            migrationBuilder.InsertData(table: "Course", columns: new[] { "ID", "Title" }, values: new object[,]
            {
                {1050,"Economy"},
                {4022,"Computer Science"},
                {4041,"Business"}
            });

            migrationBuilder.InsertData(table: "Subject", columns: new[] { "ID", "CourseID", "Title", "TeacherID" }, values: new object[,]
            {
                {11,1050, "Microeconomics",852},
                {23,1050, "Macroeconomics",852},
                {54,4022, "Databases",159},
                {57,4022, "Software Engineering",159},
                {98,4041, "Leadership",356},
                {76,4041, "Principles of Business Management",356}
            });

            migrationBuilder.InsertData(table: "Grade", columns: new[] { "ID", "Value" }, values: new object[,]
            {
                {1,"A"},
                {2,"B"},
                {3,"C"},
                {4,"D"},
                {5,"E"},
                {6,"F"}
            });

            migrationBuilder.InsertData(table: "Enrollment", columns: new[] { "StudentID", "SubjectID", "GradeID" }, values: new object[,]
            {
                {65484,11,1},
                {65284,11,2},
                {65483,11,2},
                {65481,11,3},
                {78484,11,2},
                {65984,11,4},
                {99484,11,6},

                {65484,23,2},
                {65284,23,2},
                {65483,23,6},
                {65481,23,3},
                {78484,23,2},
                {65984,23,5},
                {99484,23,1},

                {65484,54,2},
                {65284,54,3},
                {65483,54,2},
                {65481,54,3},
                {78484,54,1},
                {65984,54,1},
                {99484,54,1},

                {65484,57,2},
                {65284,57,3},
                {65483,57,2},
                {65481,57,3},
                {78484,57,1},
                {65984,57,1},
                {99484,57,1},

                {65484,98,2},
                {65284,98,1},
                {65483,98,2},
                {65481,98,1},
                {78484,98,1},
                {65984,98,1},
                {99484,98,1},

                {65484,76,2},
                {65284,76,1},
                {65483,76,2},
                {65481,76,1},
                {78484,76,3},
                {65984,76,3},
                {99484,76,5}
            });
        }
    }
}
