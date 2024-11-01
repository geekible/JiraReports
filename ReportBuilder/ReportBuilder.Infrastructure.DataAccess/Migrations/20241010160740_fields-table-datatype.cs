using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReportBuilder.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fieldstabledatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataType", "FieldAlias", "FieldName", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1475), "string", "Key", "key", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1523) },
                    { 2, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1526), "string", "Summary", "summary", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1527) },
                    { 3, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1529), "object", "Issue Type", "issuetype", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1530) },
                    { 4, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1531), "object", "Parent", "parent", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1532) },
                    { 5, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1533), "object", "Status", "status", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1534) },
                    { 6, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1536), "object", "Priority", "priority", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1537) },
                    { 7, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1538), "datetime", "Due Date", "duedate", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1539) },
                    { 8, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1540), "list<object>", "Sprints", "customfield_10020", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1541) },
                    { 9, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1542), "list<object>", "Issue Links", "issuelinks", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1543) },
                    { 10, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1545), "object", "Assigned To", "assignee", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1546) },
                    { 11, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1547), "list<object>", "History", "changelog", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1548) },
                    { 12, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1549), "list<object>", "Components", "components", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1550) },
                    { 13, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1551), "number", "Story Points", "customfield_10038", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1552) },
                    { 14, "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1553), "string", "Team", "customfield_10001", "richard", new DateTime(2024, 10, 10, 17, 7, 39, 924, DateTimeKind.Local).AddTicks(1554) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Fields");
        }
    }
}
