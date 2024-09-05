using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixPlacementOrderItemRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b1e372d8-92b3-4978-ae44-7b3e6b7a26d0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe7de3c3-b1a2-4c04-992a-cf0f47411c55"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 108, 118, 199, 180, 188, 50, 151, 103, 28, 70, 1, 46, 234, 152, 205, 177, 37, 173, 140, 54, 84, 130, 178, 46, 20, 170, 179, 119, 154, 193, 93, 10, 149, 234, 154, 254, 50, 208, 39, 91, 69, 156, 55, 228, 221, 239, 206, 81, 104, 130, 74, 26, 249, 102, 232, 68, 195, 116, 0, 43, 175, 116, 96, 242 }, new byte[] { 110, 45, 47, 233, 104, 232, 79, 214, 210, 103, 181, 232, 149, 162, 76, 164, 2, 211, 165, 251, 171, 75, 210, 230, 105, 60, 231, 13, 246, 80, 94, 242, 65, 85, 218, 172, 177, 12, 146, 173, 129, 92, 16, 247, 213, 83, 238, 181, 163, 21, 90, 202, 131, 180, 230, 50, 50, 219, 94, 39, 228, 24, 255, 113, 161, 165, 52, 140, 110, 139, 200, 253, 50, 242, 26, 217, 58, 30, 141, 179, 54, 15, 99, 84, 230, 67, 202, 169, 48, 84, 115, 116, 245, 57, 22, 161, 84, 61, 200, 104, 65, 252, 70, 220, 57, 197, 121, 122, 199, 136, 197, 82, 236, 112, 197, 100, 94, 133, 69, 25, 33, 49, 208, 34, 5, 128, 32, 80 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7bf09b0f-eef1-4aa3-b449-904b18b04985"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7bf09b0f-eef1-4aa3-b449-904b18b04985"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("fe7de3c3-b1a2-4c04-992a-cf0f47411c55"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 46, 20, 181, 157, 176, 241, 43, 175, 224, 12, 237, 210, 218, 145, 107, 203, 254, 230, 225, 216, 84, 16, 124, 83, 112, 199, 193, 161, 41, 9, 217, 106, 46, 5, 1, 148, 221, 242, 71, 135, 217, 150, 178, 9, 113, 125, 35, 13, 63, 92, 63, 178, 151, 255, 0, 44, 114, 93, 12, 58, 99, 87, 7, 180 }, new byte[] { 123, 86, 171, 66, 52, 226, 248, 58, 166, 33, 82, 77, 28, 80, 147, 112, 136, 106, 1, 88, 68, 166, 194, 209, 88, 121, 55, 136, 213, 130, 46, 47, 185, 137, 35, 64, 41, 67, 40, 74, 78, 188, 205, 53, 77, 47, 102, 218, 224, 54, 14, 149, 100, 166, 128, 242, 111, 181, 111, 198, 6, 21, 157, 244, 180, 35, 96, 33, 143, 70, 121, 249, 54, 49, 100, 78, 140, 20, 229, 251, 115, 217, 103, 170, 239, 253, 157, 52, 157, 246, 213, 63, 236, 145, 146, 71, 46, 64, 174, 26, 67, 124, 2, 19, 37, 206, 185, 23, 242, 68, 98, 152, 249, 166, 255, 107, 23, 32, 221, 93, 30, 207, 249, 75, 24, 44, 119, 178 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b1e372d8-92b3-4978-ae44-7b3e6b7a26d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("fe7de3c3-b1a2-4c04-992a-cf0f47411c55") });
        }
    }
}
