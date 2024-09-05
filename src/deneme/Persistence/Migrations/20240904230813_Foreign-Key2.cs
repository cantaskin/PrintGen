using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ab4547a0-6b08-428f-9735-04d8b3850456"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9359869-82c2-44e9-910c-bf1025df299e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f0aa5063-c989-45c1-a4dd-a759ba80beaa"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 109, 237, 41, 197, 133, 206, 93, 91, 134, 141, 73, 76, 74, 241, 123, 234, 182, 153, 236, 181, 73, 44, 176, 186, 15, 180, 95, 5, 227, 26, 193, 119, 103, 50, 67, 198, 84, 26, 88, 114, 11, 218, 208, 112, 59, 98, 30, 175, 36, 71, 157, 157, 43, 101, 116, 54, 206, 56, 175, 239, 160, 101, 157, 148 }, new byte[] { 5, 223, 3, 21, 81, 21, 236, 32, 92, 14, 112, 168, 250, 66, 179, 5, 162, 200, 154, 236, 72, 40, 224, 213, 104, 234, 97, 43, 188, 120, 177, 86, 170, 26, 77, 225, 252, 223, 2, 56, 180, 17, 34, 237, 180, 38, 98, 74, 59, 200, 82, 19, 57, 255, 118, 237, 36, 252, 129, 49, 109, 171, 90, 98, 63, 53, 189, 100, 96, 170, 169, 128, 233, 116, 213, 81, 2, 178, 231, 222, 207, 11, 237, 100, 34, 120, 254, 108, 10, 171, 213, 172, 221, 156, 171, 215, 249, 236, 47, 73, 133, 78, 103, 95, 181, 185, 2, 87, 122, 7, 105, 186, 149, 2, 203, 33, 210, 182, 252, 255, 199, 34, 237, 244, 60, 155, 115, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("77e364d7-9af3-464d-b6be-d8ad1231ef91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f0aa5063-c989-45c1-a4dd-a759ba80beaa") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("d9359869-82c2-44e9-910c-bf1025df299e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 41, 89, 214, 133, 9, 101, 18, 112, 197, 81, 85, 2, 62, 242, 60, 8, 193, 170, 225, 20, 199, 16, 133, 107, 65, 188, 60, 200, 31, 41, 132, 252, 208, 93, 26, 150, 5, 101, 213, 80, 195, 48, 106, 161, 17, 57, 10, 146, 101, 170, 110, 17, 166, 116, 148, 162, 155, 75, 136, 242, 100, 57, 223, 172 }, new byte[] { 213, 17, 245, 191, 228, 254, 164, 86, 220, 173, 98, 107, 184, 27, 10, 97, 31, 194, 31, 175, 205, 2, 104, 142, 148, 185, 192, 179, 64, 41, 14, 185, 62, 233, 30, 177, 218, 36, 43, 4, 224, 16, 128, 87, 21, 93, 3, 216, 155, 63, 16, 180, 128, 130, 255, 150, 150, 217, 157, 155, 83, 154, 71, 225, 195, 30, 194, 159, 2, 35, 211, 16, 185, 193, 7, 215, 55, 151, 182, 70, 197, 83, 238, 137, 244, 209, 187, 133, 113, 238, 162, 93, 95, 30, 7, 175, 172, 182, 50, 161, 31, 121, 113, 192, 72, 35, 97, 90, 131, 76, 255, 145, 159, 0, 253, 214, 123, 235, 154, 18, 10, 10, 115, 235, 25, 186, 240, 182 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ab4547a0-6b08-428f-9735-04d8b3850456"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d9359869-82c2-44e9-910c-bf1025df299e") });
        }
    }
}
