using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderAndOrderItemRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("77e364d7-9af3-464d-b6be-d8ad1231ef91"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0aa5063-c989-45c1-a4dd-a759ba80beaa"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("fe7de3c3-b1a2-4c04-992a-cf0f47411c55"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 46, 20, 181, 157, 176, 241, 43, 175, 224, 12, 237, 210, 218, 145, 107, 203, 254, 230, 225, 216, 84, 16, 124, 83, 112, 199, 193, 161, 41, 9, 217, 106, 46, 5, 1, 148, 221, 242, 71, 135, 217, 150, 178, 9, 113, 125, 35, 13, 63, 92, 63, 178, 151, 255, 0, 44, 114, 93, 12, 58, 99, 87, 7, 180 }, new byte[] { 123, 86, 171, 66, 52, 226, 248, 58, 166, 33, 82, 77, 28, 80, 147, 112, 136, 106, 1, 88, 68, 166, 194, 209, 88, 121, 55, 136, 213, 130, 46, 47, 185, 137, 35, 64, 41, 67, 40, 74, 78, 188, 205, 53, 77, 47, 102, 218, 224, 54, 14, 149, 100, 166, 128, 242, 111, 181, 111, 198, 6, 21, 157, 244, 180, 35, 96, 33, 143, 70, 121, 249, 54, 49, 100, 78, 140, 20, 229, 251, 115, 217, 103, 170, 239, 253, 157, 52, 157, 246, 213, 63, 236, 145, 146, 71, 46, 64, 174, 26, 67, 124, 2, 19, 37, 206, 185, 23, 242, 68, 98, 152, 249, 166, 255, 107, 23, 32, 221, 93, 30, 207, 249, 75, 24, 44, 119, 178 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b1e372d8-92b3-4978-ae44-7b3e6b7a26d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("fe7de3c3-b1a2-4c04-992a-cf0f47411c55") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("f0aa5063-c989-45c1-a4dd-a759ba80beaa"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 109, 237, 41, 197, 133, 206, 93, 91, 134, 141, 73, 76, 74, 241, 123, 234, 182, 153, 236, 181, 73, 44, 176, 186, 15, 180, 95, 5, 227, 26, 193, 119, 103, 50, 67, 198, 84, 26, 88, 114, 11, 218, 208, 112, 59, 98, 30, 175, 36, 71, 157, 157, 43, 101, 116, 54, 206, 56, 175, 239, 160, 101, 157, 148 }, new byte[] { 5, 223, 3, 21, 81, 21, 236, 32, 92, 14, 112, 168, 250, 66, 179, 5, 162, 200, 154, 236, 72, 40, 224, 213, 104, 234, 97, 43, 188, 120, 177, 86, 170, 26, 77, 225, 252, 223, 2, 56, 180, 17, 34, 237, 180, 38, 98, 74, 59, 200, 82, 19, 57, 255, 118, 237, 36, 252, 129, 49, 109, 171, 90, 98, 63, 53, 189, 100, 96, 170, 169, 128, 233, 116, 213, 81, 2, 178, 231, 222, 207, 11, 237, 100, 34, 120, 254, 108, 10, 171, 213, 172, 221, 156, 171, 215, 249, 236, 47, 73, 133, 78, 103, 95, 181, 185, 2, 87, 122, 7, 105, 186, 149, 2, 203, 33, 210, 182, 252, 255, 199, 34, 237, 244, 60, 155, 115, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("77e364d7-9af3-464d-b6be-d8ad1231ef91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f0aa5063-c989-45c1-a4dd-a759ba80beaa") });
        }
    }
}
