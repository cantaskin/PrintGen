using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ApiId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6898e9e8-fdb9-49c0-a137-23c07ab7ced5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd"));

            migrationBuilder.AddColumn<string>(
                name: "OrderApiIp",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("92a9e024-36ce-4183-ac40-73e4e1cd7e59"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 2, 85, 36, 175, 245, 203, 241, 157, 197, 137, 60, 103, 233, 234, 167, 220, 47, 89, 252, 128, 36, 145, 181, 171, 4, 55, 94, 97, 59, 140, 158, 117, 23, 40, 59, 22, 212, 97, 215, 218, 34, 159, 105, 73, 36, 95, 199, 164, 202, 36, 92, 29, 47, 173, 98, 198, 40, 47, 247, 6, 230, 4, 99, 242 }, new byte[] { 20, 163, 166, 157, 219, 254, 250, 91, 48, 147, 233, 253, 132, 30, 146, 170, 28, 195, 171, 158, 10, 250, 190, 24, 47, 126, 242, 134, 66, 244, 66, 245, 63, 43, 198, 249, 40, 189, 113, 90, 119, 232, 228, 85, 47, 220, 233, 73, 129, 141, 81, 98, 3, 240, 219, 101, 11, 224, 81, 81, 85, 183, 126, 214, 61, 222, 200, 240, 228, 79, 178, 30, 156, 196, 104, 102, 1, 75, 2, 182, 50, 249, 203, 199, 163, 175, 141, 198, 121, 59, 39, 47, 61, 189, 76, 8, 43, 234, 254, 112, 160, 164, 222, 12, 84, 219, 164, 1, 203, 253, 89, 156, 118, 160, 87, 5, 37, 174, 178, 123, 168, 209, 29, 129, 122, 111, 41, 245 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("71faeb02-5cf0-4c24-823b-254b0215644a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("92a9e024-36ce-4183-ac40-73e4e1cd7e59") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("71faeb02-5cf0-4c24-823b-254b0215644a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("92a9e024-36ce-4183-ac40-73e4e1cd7e59"));

            migrationBuilder.DropColumn(
                name: "OrderApiIp",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 146, 255, 202, 154, 149, 215, 220, 233, 254, 202, 200, 0, 9, 117, 112, 122, 158, 68, 95, 128, 227, 211, 79, 3, 99, 109, 56, 66, 228, 66, 219, 52, 156, 120, 130, 96, 70, 222, 31, 233, 101, 141, 179, 141, 156, 235, 248, 115, 244, 137, 24, 4, 97, 23, 63, 201, 119, 225, 160, 239, 33, 138, 40, 7 }, new byte[] { 213, 79, 32, 54, 172, 34, 49, 129, 44, 147, 86, 185, 9, 177, 192, 153, 83, 71, 238, 244, 129, 236, 33, 198, 132, 101, 192, 1, 60, 185, 188, 95, 252, 239, 153, 251, 248, 134, 167, 207, 115, 95, 45, 132, 20, 95, 27, 217, 61, 234, 89, 46, 253, 93, 210, 135, 127, 113, 240, 191, 158, 236, 166, 255, 140, 95, 102, 14, 148, 55, 73, 61, 119, 26, 36, 9, 91, 167, 232, 98, 175, 61, 234, 137, 251, 9, 203, 22, 86, 28, 127, 47, 69, 123, 86, 76, 95, 254, 127, 126, 213, 101, 231, 138, 120, 18, 59, 6, 236, 231, 60, 201, 21, 128, 224, 38, 233, 162, 125, 203, 221, 247, 48, 63, 244, 148, 156, 138 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6898e9e8-fdb9-49c0-a137-23c07ab7ced5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd") });
        }
    }
}
