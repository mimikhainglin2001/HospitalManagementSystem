using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UserActivityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_CreatedById",
                table: "SystemCodeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_ModifiedById",
                table: "SystemCodeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodes_AspNetUsers_CreatedById",
                table: "SystemCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodes_AspNetUsers_ModifiedById",
                table: "SystemCodes");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "SystemCodes",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "SystemCodes",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "SystemCodeDetails",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "SystemCodeDetails",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_CreatedById",
                table: "SystemCodeDetails",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_ModifiedById",
                table: "SystemCodeDetails",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodes_AspNetUsers_CreatedById",
                table: "SystemCodes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodes_AspNetUsers_ModifiedById",
                table: "SystemCodes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_CreatedById",
                table: "SystemCodeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_ModifiedById",
                table: "SystemCodeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodes_AspNetUsers_CreatedById",
                table: "SystemCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodes_AspNetUsers_ModifiedById",
                table: "SystemCodes");

            migrationBuilder.UpdateData(
                table: "SystemCodes",
                keyColumn: "ModifiedById",
                keyValue: null,
                column: "ModifiedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "SystemCodes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SystemCodes",
                keyColumn: "CreatedById",
                keyValue: null,
                column: "CreatedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "SystemCodes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SystemCodeDetails",
                keyColumn: "ModifiedById",
                keyValue: null,
                column: "ModifiedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "SystemCodeDetails",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SystemCodeDetails",
                keyColumn: "CreatedById",
                keyValue: null,
                column: "CreatedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "SystemCodeDetails",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_CreatedById",
                table: "SystemCodeDetails",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodeDetails_AspNetUsers_ModifiedById",
                table: "SystemCodeDetails",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodes_AspNetUsers_CreatedById",
                table: "SystemCodes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodes_AspNetUsers_ModifiedById",
                table: "SystemCodes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
