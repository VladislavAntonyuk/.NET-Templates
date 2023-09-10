using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App1.Infrastructure.Data.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Class1",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Name = table.Column<string>(type: "TEXT", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Class1", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Class1_Name",
				table: "Class1",
				column: "Name",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Class1");
		}
	}
}