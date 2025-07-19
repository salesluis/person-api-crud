﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Person.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Person",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
