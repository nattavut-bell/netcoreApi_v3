using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAPI_v3.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("6c44400a-64bf-48dd-b7d8-2402af4039ae"), "user" },
                    { new Guid("a49db5b3-0016-4d26-bafe-b3f4a6c78dfc"), "Manager" },
                    { new Guid("4671f930-090c-431a-987b-58f40f06a0ac"), "Admin" },
                    { new Guid("30daf03d-7ad3-45c5-b70e-332d5a697ef5"), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_CreatedByUserId",
                table: "ProductGroup",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_UpdatedByUserId",
                table: "ProductGroup",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedByUserId",
                table: "Product",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedByUserId",
                table: "Product",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreatedByUserId",
                table: "Product",
                column: "CreatedByUserId",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UpdatedByUserId",
                table: "Product",
                column: "UpdatedByUserId",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_User_CreatedByUserId",
                table: "ProductGroup",
                column: "CreatedByUserId",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_User_UpdatedByUserId",
                table: "ProductGroup",
                column: "UpdatedByUserId",
                principalSchema: "auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_CreatedByUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UpdatedByUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_User_CreatedByUserId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_User_UpdatedByUserId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_CreatedByUserId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_UpdatedByUserId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_Product_CreatedByUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedByUserId",
                table: "Product");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("30daf03d-7ad3-45c5-b70e-332d5a697ef5"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4671f930-090c-431a-987b-58f40f06a0ac"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6c44400a-64bf-48dd-b7d8-2402af4039ae"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a49db5b3-0016-4d26-bafe-b3f4a6c78dfc"));

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
        }
    }
}
