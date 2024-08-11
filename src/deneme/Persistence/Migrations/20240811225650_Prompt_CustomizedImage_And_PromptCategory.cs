using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Prompt_CustomizedImage_And_PromptCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8a19290a-f7a4-4e04-b853-c32c89d4dc5a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5c7bcf4-bff5-4a0a-b0a2-4a81ada5aad9"));

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Prompts");

            migrationBuilder.DropColumn(
                name: "PromptCategory",
                table: "Prompts");

            migrationBuilder.AddColumn<Guid>(
                name: "PromptCategoryId",
                table: "Prompts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PromptCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Admin", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Read", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Write", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Create", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Update", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("36891825-6087-45e7-ba3c-612e2bbcb990"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 142, 0, 135, 184, 16, 117, 45, 106, 36, 139, 3, 9, 57, 230, 82, 152, 142, 234, 226, 214, 42, 14, 103, 150, 222, 26, 150, 138, 146, 171, 190, 53, 95, 99, 67, 197, 116, 10, 112, 90, 231, 98, 249, 242, 186, 211, 17, 230, 67, 114, 190, 45, 205, 194, 215, 53, 215, 185, 230, 240, 0, 8, 161, 47 }, new byte[] { 202, 51, 206, 187, 174, 44, 86, 55, 144, 214, 24, 190, 95, 163, 131, 177, 110, 204, 154, 140, 196, 147, 250, 124, 194, 144, 125, 126, 146, 44, 227, 57, 241, 111, 222, 88, 37, 182, 237, 103, 16, 11, 218, 44, 244, 79, 207, 3, 231, 239, 187, 44, 84, 127, 227, 250, 107, 231, 83, 162, 105, 156, 214, 164, 128, 178, 140, 126, 239, 5, 23, 61, 45, 207, 102, 202, 7, 84, 166, 37, 154, 140, 56, 140, 149, 142, 188, 17, 234, 72, 144, 156, 40, 122, 226, 13, 78, 174, 215, 172, 144, 182, 28, 88, 89, 167, 50, 95, 14, 56, 17, 119, 85, 147, 133, 2, 124, 41, 205, 97, 243, 253, 255, 209, 182, 204, 1, 142 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("34730009-e0f3-4d86-9032-c991bf0e8cfa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("36891825-6087-45e7-ba3c-612e2bbcb990") });

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_PromptCategoryId",
                table: "Prompts",
                column: "PromptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prompts_PromptCategories_PromptCategoryId",
                table: "Prompts",
                column: "PromptCategoryId",
                principalTable: "PromptCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prompts_PromptCategories_PromptCategoryId",
                table: "Prompts");

            migrationBuilder.DropTable(
                name: "PromptCategories");

            migrationBuilder.DropIndex(
                name: "IX_Prompts_PromptCategoryId",
                table: "Prompts");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("34730009-e0f3-4d86-9032-c991bf0e8cfa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36891825-6087-45e7-ba3c-612e2bbcb990"));

            migrationBuilder.DropColumn(
                name: "PromptCategoryId",
                table: "Prompts");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Prompts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromptCategory",
                table: "Prompts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f5c7bcf4-bff5-4a0a-b0a2-4a81ada5aad9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 34, 50, 140, 98, 115, 247, 34, 224, 73, 185, 17, 47, 171, 220, 155, 45, 104, 230, 28, 139, 249, 24, 159, 189, 200, 45, 158, 176, 181, 196, 157, 39, 211, 43, 19, 117, 64, 203, 210, 164, 58, 161, 134, 85, 202, 53, 95, 106, 251, 56, 59, 16, 54, 78, 227, 140, 203, 94, 72, 33, 28, 36, 118, 69 }, new byte[] { 247, 30, 77, 238, 8, 126, 130, 211, 82, 221, 205, 4, 204, 138, 241, 22, 223, 120, 71, 204, 114, 201, 255, 250, 218, 75, 132, 156, 126, 118, 163, 25, 115, 232, 16, 81, 104, 239, 227, 92, 172, 146, 114, 65, 207, 232, 164, 106, 164, 72, 223, 177, 192, 195, 116, 30, 57, 153, 251, 224, 152, 24, 62, 15, 3, 250, 172, 96, 119, 78, 9, 113, 238, 157, 59, 137, 170, 39, 226, 184, 97, 42, 123, 128, 103, 114, 185, 228, 64, 171, 86, 40, 92, 40, 138, 14, 130, 32, 234, 52, 70, 33, 161, 214, 169, 203, 17, 93, 183, 77, 91, 238, 180, 212, 55, 93, 36, 193, 113, 165, 231, 213, 38, 53, 77, 40, 145, 106 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8a19290a-f7a4-4e04-b853-c32c89d4dc5a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f5c7bcf4-bff5-4a0a-b0a2-4a81ada5aad9") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId",
                unique: true);
        }
    }
}
