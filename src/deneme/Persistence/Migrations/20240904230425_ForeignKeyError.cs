using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_Id",
                table: "OrderItems");

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
                values: new object[] { new Guid("d9359869-82c2-44e9-910c-bf1025df299e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 41, 89, 214, 133, 9, 101, 18, 112, 197, 81, 85, 2, 62, 242, 60, 8, 193, 170, 225, 20, 199, 16, 133, 107, 65, 188, 60, 200, 31, 41, 132, 252, 208, 93, 26, 150, 5, 101, 213, 80, 195, 48, 106, 161, 17, 57, 10, 146, 101, 170, 110, 17, 166, 116, 148, 162, 155, 75, 136, 242, 100, 57, 223, 172 }, new byte[] { 213, 17, 245, 191, 228, 254, 164, 86, 220, 173, 98, 107, 184, 27, 10, 97, 31, 194, 31, 175, 205, 2, 104, 142, 148, 185, 192, 179, 64, 41, 14, 185, 62, 233, 30, 177, 218, 36, 43, 4, 224, 16, 128, 87, 21, 93, 3, 216, 155, 63, 16, 180, 128, 130, 255, 150, 150, 217, 157, 155, 83, 154, 71, 225, 195, 30, 194, 159, 2, 35, 211, 16, 185, 193, 7, 215, 55, 151, 182, 70, 197, 83, 238, 137, 244, 209, 187, 133, 113, 238, 162, 93, 95, 30, 7, 175, 172, 182, 50, 161, 31, 121, 113, 192, 72, 35, 97, 90, 131, 76, 255, 145, 159, 0, 253, 214, 123, 235, 154, 18, 10, 10, 115, 235, 25, 186, 240, 182 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ab4547a0-6b08-428f-9735-04d8b3850456"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d9359869-82c2-44e9-910c-bf1025df299e") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

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
                values: new object[] { new Guid("ec530ccb-0ba0-4c8b-9130-629b07c34645"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 233, 174, 10, 142, 146, 64, 171, 149, 190, 59, 115, 124, 107, 11, 216, 102, 27, 158, 177, 87, 185, 206, 55, 213, 101, 101, 64, 168, 195, 109, 199, 94, 68, 79, 144, 235, 164, 88, 203, 152, 251, 32, 102, 120, 11, 126, 138, 173, 42, 64, 231, 172, 93, 113, 16, 221, 140, 53, 228, 89, 149, 25, 137, 148 }, new byte[] { 100, 255, 169, 46, 142, 70, 183, 121, 12, 37, 7, 72, 171, 109, 53, 77, 59, 134, 167, 179, 7, 204, 71, 55, 1, 192, 14, 238, 127, 145, 109, 199, 82, 226, 154, 125, 70, 81, 205, 145, 110, 14, 252, 33, 50, 87, 106, 20, 5, 196, 163, 232, 115, 98, 226, 9, 90, 177, 185, 209, 83, 198, 233, 118, 167, 210, 110, 247, 237, 42, 222, 160, 214, 117, 157, 160, 118, 192, 2, 19, 96, 230, 166, 152, 88, 35, 200, 36, 140, 104, 211, 67, 75, 191, 150, 137, 89, 15, 69, 130, 173, 220, 255, 104, 26, 219, 35, 220, 199, 252, 221, 17, 26, 245, 24, 228, 177, 29, 15, 117, 18, 77, 143, 230, 206, 99, 11, 184 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d36c01c7-ebda-4696-8662-10d08879bd8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ec530ccb-0ba0-4c8b-9130-629b07c34645") });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_Id",
                table: "OrderItems",
                column: "Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
