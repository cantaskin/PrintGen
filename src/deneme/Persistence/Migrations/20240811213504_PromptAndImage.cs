using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PromptAndImage : Migration
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2b1a2487-0902-4dce-9e5a-c5b832eda282"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 113, 57, 148, 67, 208, 170, 65, 204, 219, 29, 33, 195, 159, 45, 228, 212, 99, 137, 153, 13, 13, 242, 173, 85, 237, 164, 73, 96, 113, 45, 46, 242, 98, 201, 151, 81, 129, 22, 132, 95, 191, 250, 109, 139, 46, 191, 159, 118, 207, 240, 196, 18, 225, 66, 136, 16, 200, 105, 17, 46, 147, 120, 179, 232 }, new byte[] { 67, 117, 87, 143, 10, 136, 14, 196, 78, 49, 129, 115, 75, 164, 223, 213, 254, 13, 135, 222, 26, 224, 223, 218, 216, 219, 95, 184, 125, 114, 109, 121, 21, 222, 26, 117, 103, 235, 52, 107, 48, 245, 187, 21, 111, 87, 197, 139, 155, 150, 37, 196, 38, 178, 130, 47, 54, 142, 179, 4, 105, 205, 58, 58, 31, 206, 241, 127, 1, 251, 185, 250, 149, 237, 143, 60, 198, 35, 45, 204, 204, 142, 246, 5, 28, 252, 134, 19, 139, 119, 121, 87, 74, 41, 138, 240, 242, 55, 218, 198, 176, 27, 90, 26, 242, 243, 186, 18, 57, 248, 14, 86, 205, 190, 132, 28, 129, 161, 175, 162, 35, 138, 137, 167, 16, 79, 81, 216 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("25af81fb-43ae-47fd-8ce0-2069fe9f6194"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2b1a2487-0902-4dce-9e5a-c5b832eda282") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("25af81fb-43ae-47fd-8ce0-2069fe9f6194"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b1a2487-0902-4dce-9e5a-c5b832eda282"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Prompts",
                type: "uniqueidentifier",
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
