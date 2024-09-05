using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("25e246f8-83a9-4796-8502-b522f664c269"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ec530ccb-0ba0-4c8b-9130-629b07c34645"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 233, 174, 10, 142, 146, 64, 171, 149, 190, 59, 115, 124, 107, 11, 216, 102, 27, 158, 177, 87, 185, 206, 55, 213, 101, 101, 64, 168, 195, 109, 199, 94, 68, 79, 144, 235, 164, 88, 203, 152, 251, 32, 102, 120, 11, 126, 138, 173, 42, 64, 231, 172, 93, 113, 16, 221, 140, 53, 228, 89, 149, 25, 137, 148 }, new byte[] { 100, 255, 169, 46, 142, 70, 183, 121, 12, 37, 7, 72, 171, 109, 53, 77, 59, 134, 167, 179, 7, 204, 71, 55, 1, 192, 14, 238, 127, 145, 109, 199, 82, 226, 154, 125, 70, 81, 205, 145, 110, 14, 252, 33, 50, 87, 106, 20, 5, 196, 163, 232, 115, 98, 226, 9, 90, 177, 185, 209, 83, 198, 233, 118, 167, 210, 110, 247, 237, 42, 222, 160, 214, 117, 157, 160, 118, 192, 2, 19, 96, 230, 166, 152, 88, 35, 200, 36, 140, 104, 211, 67, 75, 191, 150, 137, 89, 15, 69, 130, 173, 220, 255, 104, 26, 219, 35, 220, 199, 252, 221, 17, 26, 245, 24, 228, 177, 29, 15, 117, 18, 77, 143, 230, 206, 99, 11, 184 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d36c01c7-ebda-4696-8662-10d08879bd8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ec530ccb-0ba0-4c8b-9130-629b07c34645") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d36c01c7-ebda-4696-8662-10d08879bd8f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec530ccb-0ba0-4c8b-9130-629b07c34645"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 94, 249, 166, 179, 52, 206, 45, 174, 24, 83, 144, 8, 148, 90, 13, 137, 80, 76, 100, 110, 228, 125, 215, 43, 244, 130, 130, 210, 17, 101, 39, 66, 189, 202, 56, 83, 81, 155, 154, 180, 57, 82, 41, 126, 30, 83, 107, 79, 213, 196, 189, 146, 101, 247, 47, 159, 103, 44, 240, 162, 223, 142, 106, 160 }, new byte[] { 173, 88, 234, 112, 36, 81, 22, 81, 122, 20, 202, 72, 77, 248, 8, 156, 195, 1, 123, 26, 233, 167, 179, 43, 156, 16, 195, 133, 25, 145, 160, 45, 103, 150, 163, 178, 161, 60, 41, 77, 44, 178, 177, 13, 35, 202, 74, 28, 19, 13, 219, 155, 207, 219, 104, 172, 251, 193, 34, 15, 163, 115, 238, 48, 128, 242, 174, 179, 244, 50, 26, 3, 192, 248, 96, 58, 215, 188, 58, 29, 191, 189, 196, 234, 73, 203, 245, 116, 155, 9, 147, 121, 224, 82, 57, 94, 251, 45, 176, 101, 213, 105, 155, 189, 112, 216, 34, 122, 43, 101, 228, 251, 235, 160, 78, 230, 124, 22, 4, 118, 8, 132, 117, 125, 144, 154, 181, 34 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("25e246f8-83a9-4796-8502-b522f664c269"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb") });
        }
    }
}
