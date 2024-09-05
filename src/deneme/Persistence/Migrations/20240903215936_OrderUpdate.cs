using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CustomizationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RetailCostId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 94, 249, 166, 179, 52, 206, 45, 174, 24, 83, 144, 8, 148, 90, 13, 137, 80, 76, 100, 110, 228, 125, 215, 43, 244, 130, 130, 210, 17, 101, 39, 66, 189, 202, 56, 83, 81, 155, 154, 180, 57, 82, 41, 126, 30, 83, 107, 79, 213, 196, 189, 146, 101, 247, 47, 159, 103, 44, 240, 162, 223, 142, 106, 160 }, new byte[] { 173, 88, 234, 112, 36, 81, 22, 81, 122, 20, 202, 72, 77, 248, 8, 156, 195, 1, 123, 26, 233, 167, 179, 43, 156, 16, 195, 133, 25, 145, 160, 45, 103, 150, 163, 178, 161, 60, 41, 77, 44, 178, 177, 13, 35, 202, 74, 28, 19, 13, 219, 155, 207, 219, 104, 172, 251, 193, 34, 15, 163, 115, 238, 48, 128, 242, 174, 179, 244, 50, 26, 3, 192, 248, 96, 58, 215, 188, 58, 29, 191, 189, 196, 234, 73, 203, 245, 116, 155, 9, 147, 121, 224, 82, 57, 94, 251, 45, 176, 101, 213, 105, 155, 189, 112, 216, 34, 122, 43, 101, 228, 251, 235, 160, 78, 230, 124, 22, 4, 118, 8, 132, 117, 125, 144, 154, 181, 34 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("25e246f8-83a9-4796-8502-b522f664c269"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("25e246f8-83a9-4796-8502-b522f664c269"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3acfc8fe-52b5-46a3-a0c9-282c6d1aecdb"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomizationId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RetailCostId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("92a9e024-36ce-4183-ac40-73e4e1cd7e59"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 2, 85, 36, 175, 245, 203, 241, 157, 197, 137, 60, 103, 233, 234, 167, 220, 47, 89, 252, 128, 36, 145, 181, 171, 4, 55, 94, 97, 59, 140, 158, 117, 23, 40, 59, 22, 212, 97, 215, 218, 34, 159, 105, 73, 36, 95, 199, 164, 202, 36, 92, 29, 47, 173, 98, 198, 40, 47, 247, 6, 230, 4, 99, 242 }, new byte[] { 20, 163, 166, 157, 219, 254, 250, 91, 48, 147, 233, 253, 132, 30, 146, 170, 28, 195, 171, 158, 10, 250, 190, 24, 47, 126, 242, 134, 66, 244, 66, 245, 63, 43, 198, 249, 40, 189, 113, 90, 119, 232, 228, 85, 47, 220, 233, 73, 129, 141, 81, 98, 3, 240, 219, 101, 11, 224, 81, 81, 85, 183, 126, 214, 61, 222, 200, 240, 228, 79, 178, 30, 156, 196, 104, 102, 1, 75, 2, 182, 50, 249, 203, 199, 163, 175, 141, 198, 121, 59, 39, 47, 61, 189, 76, 8, 43, 234, 254, 112, 160, 164, 222, 12, 84, 219, 164, 1, 203, 253, 89, 156, 118, 160, 87, 5, 37, 174, 178, 123, 168, 209, 29, 129, 122, 111, 41, 245 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("71faeb02-5cf0-4c24-823b-254b0215644a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("92a9e024-36ce-4183-ac40-73e4e1cd7e59") });
        }
    }
}
