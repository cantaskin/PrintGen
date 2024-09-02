using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Order1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placements_OrderItems_OrderItemId1",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Placements_OrderItemId1",
                table: "Placements");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a8dff8b3-8b88-4655-963a-dae458d219e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8cc4ee43-9d11-4bfa-be6d-1b24e6f88972"));

            migrationBuilder.DropColumn(
                name: "OrderItemId1",
                table: "Placements");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 146, 255, 202, 154, 149, 215, 220, 233, 254, 202, 200, 0, 9, 117, 112, 122, 158, 68, 95, 128, 227, 211, 79, 3, 99, 109, 56, 66, 228, 66, 219, 52, 156, 120, 130, 96, 70, 222, 31, 233, 101, 141, 179, 141, 156, 235, 248, 115, 244, 137, 24, 4, 97, 23, 63, 201, 119, 225, 160, 239, 33, 138, 40, 7 }, new byte[] { 213, 79, 32, 54, 172, 34, 49, 129, 44, 147, 86, 185, 9, 177, 192, 153, 83, 71, 238, 244, 129, 236, 33, 198, 132, 101, 192, 1, 60, 185, 188, 95, 252, 239, 153, 251, 248, 134, 167, 207, 115, 95, 45, 132, 20, 95, 27, 217, 61, 234, 89, 46, 253, 93, 210, 135, 127, 113, 240, 191, 158, 236, 166, 255, 140, 95, 102, 14, 148, 55, 73, 61, 119, 26, 36, 9, 91, 167, 232, 98, 175, 61, 234, 137, 251, 9, 203, 22, 86, 28, 127, 47, 69, 123, 86, 76, 95, 254, 127, 126, 213, 101, 231, 138, 120, 18, 59, 6, 236, 231, 60, 201, 21, 128, 224, 38, 233, 162, 125, 203, 221, 247, 48, 63, 244, 148, 156, 138 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6898e9e8-fdb9-49c0-a137-23c07ab7ced5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd") });

            migrationBuilder.CreateIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_OrderItems_OrderItemId",
                table: "Placements",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placements_OrderItems_OrderItemId",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6898e9e8-fdb9-49c0-a137-23c07ab7ced5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f220437c-2e1b-4ff1-a1b4-843f2be860dd"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId1",
                table: "Placements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("8cc4ee43-9d11-4bfa-be6d-1b24e6f88972"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", new byte[] { 98, 212, 95, 167, 48, 144, 154, 100, 139, 27, 119, 161, 133, 14, 167, 71, 251, 249, 140, 248, 77, 105, 160, 145, 17, 177, 177, 227, 111, 124, 60, 225, 10, 138, 49, 162, 165, 171, 240, 181, 96, 75, 207, 105, 250, 175, 184, 78, 64, 245, 5, 52, 204, 216, 18, 127, 143, 228, 153, 41, 116, 78, 97, 129 }, new byte[] { 199, 248, 96, 63, 145, 185, 29, 49, 147, 74, 155, 74, 8, 51, 222, 149, 75, 10, 93, 155, 132, 118, 190, 236, 71, 85, 2, 57, 103, 141, 66, 87, 46, 249, 112, 146, 244, 165, 246, 225, 231, 9, 58, 183, 188, 91, 204, 38, 84, 245, 148, 131, 73, 91, 108, 194, 148, 195, 214, 227, 94, 182, 216, 127, 57, 186, 248, 169, 60, 122, 92, 118, 248, 16, 124, 90, 243, 153, 60, 242, 89, 167, 6, 114, 85, 195, 76, 31, 66, 241, 202, 66, 2, 243, 51, 119, 153, 184, 243, 233, 68, 27, 9, 143, 196, 199, 188, 64, 1, 170, 254, 35, 26, 193, 24, 89, 68, 41, 130, 123, 190, 57, 122, 242, 247, 51, 160, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a8dff8b3-8b88-4655-963a-dae458d219e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8cc4ee43-9d11-4bfa-be6d-1b24e6f88972") });

            migrationBuilder.CreateIndex(
                name: "IX_Placements_OrderItemId1",
                table: "Placements",
                column: "OrderItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_OrderItems_OrderItemId1",
                table: "Placements",
                column: "OrderItemId1",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
