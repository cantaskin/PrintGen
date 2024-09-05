using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixPlacementOrderItemRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7bf09b0f-eef1-4aa3-b449-904b18b04985"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c"));

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Layers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("59f8e2da-3d7f-46fb-a154-e0a59a0eae60"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 208, 114, 171, 73, 141, 204, 220, 95, 186, 111, 185, 228, 125, 30, 77, 247, 61, 90, 109, 207, 240, 248, 186, 147, 228, 130, 228, 244, 175, 126, 248, 146, 192, 40, 211, 250, 209, 182, 152, 220, 39, 208, 35, 154, 207, 248, 185, 161, 238, 52, 152, 110, 208, 169, 206, 44, 101, 244, 31, 179, 230, 149, 70, 93 }, new byte[] { 200, 24, 64, 73, 182, 96, 13, 240, 116, 29, 47, 146, 247, 223, 129, 92, 98, 38, 252, 217, 201, 77, 107, 183, 56, 46, 174, 16, 38, 189, 27, 51, 152, 12, 207, 253, 255, 9, 89, 81, 59, 160, 77, 115, 68, 86, 10, 186, 250, 49, 138, 240, 37, 149, 143, 121, 122, 66, 193, 90, 178, 182, 7, 189, 172, 214, 196, 95, 232, 175, 25, 144, 165, 131, 159, 221, 171, 150, 88, 190, 16, 241, 214, 146, 215, 194, 38, 139, 90, 104, 104, 100, 7, 223, 143, 111, 231, 65, 212, 59, 242, 233, 19, 216, 66, 131, 191, 88, 112, 87, 184, 190, 124, 200, 221, 74, 24, 121, 183, 38, 27, 202, 135, 215, 191, 252, 158, 58 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("27918a65-9ef6-4141-9cf2-581cfeede5e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("59f8e2da-3d7f-46fb-a154-e0a59a0eae60") });

            migrationBuilder.CreateIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements",
                column: "OrderItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("27918a65-9ef6-4141-9cf2-581cfeede5e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("59f8e2da-3d7f-46fb-a154-e0a59a0eae60"));

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "PlacementId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 108, 118, 199, 180, 188, 50, 151, 103, 28, 70, 1, 46, 234, 152, 205, 177, 37, 173, 140, 54, 84, 130, 178, 46, 20, 170, 179, 119, 154, 193, 93, 10, 149, 234, 154, 254, 50, 208, 39, 91, 69, 156, 55, 228, 221, 239, 206, 81, 104, 130, 74, 26, 249, 102, 232, 68, 195, 116, 0, 43, 175, 116, 96, 242 }, new byte[] { 110, 45, 47, 233, 104, 232, 79, 214, 210, 103, 181, 232, 149, 162, 76, 164, 2, 211, 165, 251, 171, 75, 210, 230, 105, 60, 231, 13, 246, 80, 94, 242, 65, 85, 218, 172, 177, 12, 146, 173, 129, 92, 16, 247, 213, 83, 238, 181, 163, 21, 90, 202, 131, 180, 230, 50, 50, 219, 94, 39, 228, 24, 255, 113, 161, 165, 52, 140, 110, 139, 200, 253, 50, 242, 26, 217, 58, 30, 141, 179, 54, 15, 99, 84, 230, 67, 202, 169, 48, 84, 115, 116, 245, 57, 22, 161, 84, 61, 200, 104, 65, 252, 70, 220, 57, 197, 121, 122, 199, 136, 197, 82, 236, 112, 197, 100, 94, 133, 69, 25, 33, 49, 208, 34, 5, 128, 32, 80 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7bf09b0f-eef1-4aa3-b449-904b18b04985"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e05ea876-ec43-4602-92a1-0f1651163f7c") });

            migrationBuilder.CreateIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements",
                column: "OrderItemId",
                unique: true);
        }
    }
}
