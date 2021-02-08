using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAPI_v3.Migrations
{
    public partial class productGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("471ec86f-5610-4d24-91a2-bce903916da8"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6fd30fee-e9b9-49bc-bd11-bdc134f42ea0"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8c27d977-9253-4896-82d2-e4f7e4fbbdb7"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ab96f6ab-5188-435a-94ea-1917a9070537"));

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f66621c-8331-464e-97dd-6f1be4c676ff"), "user" },
                    { new Guid("b86596d6-5c1d-42e4-87c9-e40d7699adae"), "Manager" },
                    { new Guid("3419ee0d-200e-4a1e-bbda-15561c39bee2"), "Admin" },
                    { new Guid("c652cff8-b844-4edf-95aa-8969c87970dc"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                table: "Product",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3419ee0d-200e-4a1e-bbda-15561c39bee2"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3f66621c-8331-464e-97dd-6f1be4c676ff"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b86596d6-5c1d-42e4-87c9-e40d7699adae"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c652cff8-b844-4edf-95aa-8969c87970dc"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6fd30fee-e9b9-49bc-bd11-bdc134f42ea0"), "user" },
                    { new Guid("ab96f6ab-5188-435a-94ea-1917a9070537"), "Manager" },
                    { new Guid("8c27d977-9253-4896-82d2-e4f7e4fbbdb7"), "Admin" },
                    { new Guid("471ec86f-5610-4d24-91a2-bce903916da8"), "Developer" }
                });
        }
    }
}
