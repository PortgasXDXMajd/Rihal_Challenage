﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using rihal_challenge.Models;

#nullable disable

namespace rihal_challenge.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class_table",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_table", x => x.ClassId);
                });


            migrationBuilder.CreateTable(
                name: "country_table",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country_table", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "student_table",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_table", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_student_table_class_table_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class_table",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_table_country_table_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country_table",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_table_ClassId",
                table: "student_table",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_student_table_CountryId",
                table: "student_table",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_table");

            migrationBuilder.DropTable(
                name: "class_table");

            migrationBuilder.DropTable(
                name: "country_table");
        }
    }
}
