using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingSlips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingSlips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromptCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromptString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromptCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompts_PromptCategories_PromptCategoryId",
                        column: x => x.PromptCategoryId,
                        principalTable: "PromptCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prompts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Shipping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderApiIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomizedImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomizedImages_Prompts_PromptId",
                        column: x => x.PromptId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomizedImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackingSlipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customizations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_PackingSlips_PackingSlipId",
                        column: x => x.PackingSlipId,
                        principalTable: "PackingSlips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogVariantId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RetailPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetailCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetailCosts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gifts_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placements_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateProducts_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Layers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layers_Placements_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Options_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Options_Placements_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "Placements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Top = table.Column<float>(type: "real", nullable: false),
                    Left = table.Column<float>(type: "real", nullable: false),
                    LayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1612, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 1613, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 1614, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 1615, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 1616, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 1617, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 1618, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 1619, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 1620, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 1621, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 1622, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 1623, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 1624, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 1625, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 1626, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 1627, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 1628, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 1629, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 1630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 1631, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 1632, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 1633, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 1634, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 1635, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Admin", null },
                    { 1636, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Read", null },
                    { 1637, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Write", null },
                    { 1638, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Create", null },
                    { 1639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Update", null },
                    { 1640, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Delete", null },
                    { 1641, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Admin", null },
                    { 1642, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Read", null },
                    { 1643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Write", null },
                    { 1644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Create", null },
                    { 1645, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Update", null },
                    { 1646, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Delete", null },
                    { 1647, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Admin", null },
                    { 1648, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Read", null },
                    { 1649, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Write", null },
                    { 1650, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Create", null },
                    { 1651, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Update", null },
                    { 1652, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Delete", null },
                    { 1653, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Admin", null },
                    { 1654, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Read", null },
                    { 1655, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Write", null },
                    { 1656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Create", null },
                    { 1657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Update", null },
                    { 1658, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Delete", null },
                    { 1659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Admin", null },
                    { 1660, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Read", null },
                    { 1661, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Write", null },
                    { 1662, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Create", null },
                    { 1663, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Update", null },
                    { 1664, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Delete", null },
                    { 1665, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Admin", null },
                    { 1666, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Read", null },
                    { 1667, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Write", null },
                    { 1668, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Create", null },
                    { 1669, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Update", null },
                    { 1670, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Delete", null },
                    { 1671, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Admin", null },
                    { 1672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Read", null },
                    { 1673, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Write", null },
                    { 1674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Create", null },
                    { 1675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Update", null },
                    { 1676, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Delete", null },
                    { 1677, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Admin", null },
                    { 1678, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Read", null },
                    { 1679, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Write", null },
                    { 1680, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Create", null },
                    { 1681, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Update", null },
                    { 1682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Delete", null },
                    { 1683, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Admin", null },
                    { 1684, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Read", null },
                    { 1685, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Write", null },
                    { 1686, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Create", null },
                    { 1687, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Update", null },
                    { 1688, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Delete", null },
                    { 1689, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Admin", null },
                    { 1690, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Read", null },
                    { 1691, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Write", null },
                    { 1692, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Create", null },
                    { 1693, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Update", null },
                    { 1694, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Delete", null },
                    { 1695, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Admin", null },
                    { 1696, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Read", null },
                    { 1697, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Write", null },
                    { 1698, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Create", null },
                    { 1699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Update", null },
                    { 1700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Delete", null },
                    { 1701, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Admin", null },
                    { 1702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Read", null },
                    { 1703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Write", null },
                    { 1704, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Create", null },
                    { 1705, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Update", null },
                    { 1706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Delete", null },
                    { 1707, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Admin", null },
                    { 1708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Read", null },
                    { 1709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Write", null },
                    { 1710, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Create", null },
                    { 1711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Update", null },
                    { 1712, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Delete", null },
                    { 1713, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Admin", null },
                    { 1714, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Read", null },
                    { 1715, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Write", null },
                    { 1716, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Create", null },
                    { 1717, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Update", null },
                    { 1718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Delete", null },
                    { 1719, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Admin", null },
                    { 1720, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Read", null },
                    { 1721, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Write", null },
                    { 1722, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Create", null },
                    { 1723, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Update", null },
                    { 1724, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Delete", null },
                    { 2018, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", null },
                    { 2019, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 2020, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 2021, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 2022, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 2023, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 2024, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 2025, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 2026, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 2027, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 2028, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 2029, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 2030, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 2031, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 2032, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 2033, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 2034, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 2035, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 2036, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 2037, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 2038, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 2039, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 2040, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 2041, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Admin", null },
                    { 2042, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Read", null },
                    { 2043, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Write", null },
                    { 2044, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Create", null },
                    { 2045, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Update", null },
                    { 2046, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prompts.Delete", null },
                    { 2047, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Admin", null },
                    { 2048, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Read", null },
                    { 2049, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Write", null },
                    { 2050, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Create", null },
                    { 2051, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Update", null },
                    { 2052, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomizedImages.Delete", null },
                    { 2053, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Admin", null },
                    { 2054, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Read", null },
                    { 2055, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Write", null },
                    { 2056, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Create", null },
                    { 2057, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Update", null },
                    { 2058, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PromptCategories.Delete", null },
                    { 2059, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Admin", null },
                    { 2060, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Read", null },
                    { 2061, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Write", null },
                    { 2062, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Create", null },
                    { 2063, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Update", null },
                    { 2064, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Addresses.Delete", null },
                    { 2065, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Admin", null },
                    { 2066, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Read", null },
                    { 2067, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Write", null },
                    { 2068, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Create", null },
                    { 2069, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Update", null },
                    { 2070, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gifts.Delete", null },
                    { 2071, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Admin", null },
                    { 2072, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Read", null },
                    { 2073, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Write", null },
                    { 2074, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Create", null },
                    { 2075, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Update", null },
                    { 2076, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Layers.Delete", null },
                    { 2077, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Admin", null },
                    { 2078, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Read", null },
                    { 2079, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Write", null },
                    { 2080, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Create", null },
                    { 2081, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Update", null },
                    { 2082, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orders.Delete", null },
                    { 2083, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Admin", null },
                    { 2084, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Read", null },
                    { 2085, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Write", null },
                    { 2086, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Create", null },
                    { 2087, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Update", null },
                    { 2088, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OrderItems.Delete", null },
                    { 2089, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Admin", null },
                    { 2090, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Read", null },
                    { 2091, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Write", null },
                    { 2092, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Create", null },
                    { 2093, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Update", null },
                    { 2094, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Placements.Delete", null },
                    { 2095, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Admin", null },
                    { 2096, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Read", null },
                    { 2097, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Write", null },
                    { 2098, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Create", null },
                    { 2099, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Update", null },
                    { 2100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Positions.Delete", null },
                    { 2101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Admin", null },
                    { 2102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Read", null },
                    { 2103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Write", null },
                    { 2104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Create", null },
                    { 2105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Update", null },
                    { 2106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RetailCosts.Delete", null },
                    { 2107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Admin", null },
                    { 2108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Read", null },
                    { 2109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Write", null },
                    { 2110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Create", null },
                    { 2111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Update", null },
                    { 2112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customizations.Delete", null },
                    { 2113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Admin", null },
                    { 2114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Read", null },
                    { 2115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Write", null },
                    { 2116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Create", null },
                    { 2117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Update", null },
                    { 2118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PackingSlips.Delete", null },
                    { 2119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Admin", null },
                    { 2120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Read", null },
                    { 2121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Write", null },
                    { 2122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Create", null },
                    { 2123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Update", null },
                    { 2124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Options.Delete", null },
                    { 2125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Admin", null },
                    { 2126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Read", null },
                    { 2127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Write", null },
                    { 2128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Create", null },
                    { 2129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Update", null },
                    { 2130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TemplateProducts.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "PackingSlips",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "LogoUrl", "Message", "Phone", "StoreName", "UpdatedDate" },
                values: new object[] { new Guid("043a460f-03fe-4811-9197-5326286519c6"), new DateTime(2024, 9, 15, 3, 33, 59, 990, DateTimeKind.Local).AddTicks(2028), null, "myCrazyip@proton.me", "https://upload.wikimedia.org/wikipedia/commons/8/8d/42_Logo.svg", "Made by Deneme", "+905432133422", "Deneme", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("15b9521a-ba70-4658-98f1-aa7942d5a2ec"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "myCrazyip@proton.me", "Mahmut", "Tuncer", new byte[] { 10, 249, 42, 90, 0, 33, 6, 167, 219, 169, 15, 140, 193, 40, 142, 140, 47, 35, 163, 72, 245, 154, 216, 135, 103, 67, 99, 21, 74, 104, 11, 14, 132, 94, 56, 93, 216, 152, 36, 180, 0, 143, 228, 37, 252, 145, 129, 60, 125, 55, 188, 172, 239, 32, 208, 109, 5, 105, 181, 104, 138, 51, 32, 157 }, new byte[] { 162, 25, 53, 38, 194, 249, 27, 14, 63, 142, 7, 197, 159, 173, 84, 91, 130, 77, 149, 82, 21, 105, 8, 143, 130, 127, 233, 251, 6, 84, 109, 167, 21, 70, 22, 180, 134, 40, 167, 176, 12, 224, 224, 63, 47, 43, 225, 157, 122, 211, 56, 175, 69, 111, 53, 110, 207, 162, 80, 238, 167, 59, 204, 52, 189, 94, 20, 133, 225, 23, 150, 21, 165, 167, 210, 5, 66, 154, 81, 183, 52, 195, 156, 82, 157, 190, 0, 31, 186, 39, 152, 80, 112, 62, 122, 161, 12, 61, 178, 13, 163, 89, 148, 163, 138, 146, 18, 238, 60, 98, 23, 221, 209, 141, 93, 165, 65, 208, 19, 232, 72, 147, 217, 206, 69, 103, 30, 166 }, "+9012354353", null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "Company", "CountryCode", "CountryName", "CreatedDate", "DeletedDate", "Email", "Name", "Phone", "StateCode", "StateName", "TaxNumber", "UpdatedDate", "UserId", "Zip" },
                values: new object[] { new Guid("846dc1aa-5417-4567-a38d-5bee762b5125"), "19749 Dearborn St", "string", "Chatsworth", "John Smith Inc", "US", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "firstname.secondname@domain.com", "John Smith", "2312322334", "CA", "California", "123.456.789-10", null, new Guid("15b9521a-ba70-4658-98f1-aa7942d5a2ec"), "91311" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8636956a-1f3f-4d0d-a7d2-c03c2050d833"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1612, null, new Guid("15b9521a-ba70-4658-98f1-aa7942d5a2ec") });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_OrderId",
                table: "Customizations",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_PackingSlipId",
                table: "Customizations",
                column: "PackingSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_PromptId",
                table: "CustomizedImages",
                column: "PromptId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedImages_UserId",
                table: "CustomizedImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CustomizationId",
                table: "Gifts",
                column: "CustomizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Layers_PlacementId",
                table: "Layers",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_LayerId",
                table: "Options",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OrderItemId",
                table: "Options",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_PlacementId",
                table: "Options",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_OrderItemId",
                table: "Placements",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_LayerId",
                table: "Positions",
                column: "LayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_PromptCategoryId",
                table: "Prompts",
                column: "PromptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_UserId",
                table: "Prompts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RetailCosts_OrderId",
                table: "RetailCosts",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProducts_OrderItemId",
                table: "TemplateProducts",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateProducts_UserId",
                table: "TemplateProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomizedImages");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RetailCosts");

            migrationBuilder.DropTable(
                name: "TemplateProducts");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "Layers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "PromptCategories");

            migrationBuilder.DropTable(
                name: "PackingSlips");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
