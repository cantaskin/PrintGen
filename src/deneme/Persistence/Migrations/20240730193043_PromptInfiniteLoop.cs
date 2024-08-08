using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PromptInfiniteLoop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedImages_Prompts_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7273dc1e-1ff6-4b19-bcd5-277659312231"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9cdd9c91-2254-490d-bc31-9d9af50942e8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("02d4670c-159b-4a2f-b058-fa32e46994e3"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 69, 23, 172, 182, 4, 157, 143, 152, 205, 38, 19, 35, 95, 98, 163, 9, 198, 201, 129, 232, 239, 202, 146, 16, 207, 79, 18, 250, 195, 121, 244, 19, 44, 72, 247, 70, 181, 193, 61, 217, 224, 71, 176, 37, 156, 172, 188, 17, 47, 57, 65, 55, 124, 42, 31, 9, 233, 231, 1, 14, 151, 156, 167, 236 }, new byte[] { 108, 58, 202, 177, 82, 32, 65, 115, 197, 95, 18, 235, 219, 214, 15, 234, 174, 218, 23, 4, 255, 11, 250, 82, 108, 96, 181, 242, 33, 193, 79, 100, 42, 126, 74, 56, 191, 183, 72, 43, 93, 252, 87, 19, 253, 0, 187, 190, 62, 208, 56, 48, 72, 241, 104, 139, 26, 200, 42, 200, 12, 234, 148, 11, 91, 240, 74, 93, 37, 32, 109, 147, 154, 86, 39, 241, 202, 225, 136, 238, 189, 95, 45, 248, 150, 151, 116, 51, 148, 112, 78, 126, 228, 144, 215, 251, 154, 115, 178, 40, 189, 153, 43, 113, 74, 254, 176, 174, 124, 157, 213, 28, 23, 61, 170, 162, 172, 23, 25, 97, 4, 223, 164, 3, 42, 128, 18, 82 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c4f95bb4-33fb-4af8-844e-dbe1a7564797"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("02d4670c-159b-4a2f-b058-fa32e46994e3") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedImages_Prompts_PromptId",
                table: "CustomizedImages",
                column: "PromptId",
                principalTable: "Prompts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedImages_Prompts_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c4f95bb4-33fb-4af8-844e-dbe1a7564797"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02d4670c-159b-4a2f-b058-fa32e46994e3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9cdd9c91-2254-490d-bc31-9d9af50942e8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 121, 190, 1, 91, 173, 85, 135, 162, 16, 101, 75, 25, 182, 123, 138, 61, 187, 236, 228, 55, 138, 110, 204, 169, 192, 115, 119, 209, 13, 107, 33, 210, 68, 223, 202, 158, 32, 205, 22, 160, 66, 234, 32, 61, 87, 71, 255, 107, 240, 150, 101, 78, 105, 90, 104, 72, 169, 167, 164, 5, 63, 27, 71, 42 }, new byte[] { 92, 115, 216, 51, 237, 75, 115, 56, 55, 16, 215, 222, 195, 27, 21, 41, 104, 151, 243, 49, 115, 100, 156, 105, 54, 60, 15, 83, 138, 99, 118, 18, 36, 42, 220, 121, 78, 192, 186, 160, 253, 159, 68, 117, 161, 83, 216, 18, 59, 61, 1, 68, 14, 49, 41, 172, 22, 147, 32, 231, 188, 204, 166, 25, 108, 242, 179, 196, 180, 79, 196, 59, 77, 247, 65, 162, 105, 97, 146, 80, 212, 11, 131, 86, 175, 118, 126, 65, 68, 47, 30, 165, 148, 83, 203, 249, 253, 42, 171, 26, 156, 248, 86, 148, 218, 6, 112, 201, 167, 214, 140, 230, 198, 172, 196, 38, 14, 71, 101, 226, 123, 44, 198, 157, 118, 27, 154, 240 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7273dc1e-1ff6-4b19-bcd5-277659312231"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9cdd9c91-2254-490d-bc31-9d9af50942e8") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedImages_Prompts_PromptId",
                table: "CustomizedImages",
                column: "PromptId",
                principalTable: "Prompts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
