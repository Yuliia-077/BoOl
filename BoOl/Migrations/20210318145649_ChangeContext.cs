using Microsoft.EntityFrameworkCore.Migrations;

namespace BoOl.Migrations
{
    public partial class ChangeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomService_Order_OrderId",
                table: "CustomService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomService_Part_PartId",
                table: "CustomService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomService_Service_ServiceId",
                table: "CustomService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomService_Workers_WorkerId",
                table: "CustomService");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Workers_WorkerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Storage_StorageId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Customer_CustomerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Model_ModelId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Model_ModelId",
                table: "Storage");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Workers_WorkerId",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomService",
                table: "CustomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Parts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "CustomService",
                newName: "CustomServices");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_WorkerId",
                table: "Storages",
                newName: "IX_Storages_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_ModelId",
                table: "Storages",
                newName: "IX_Storages_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ModelId",
                table: "Products",
                newName: "IX_Products_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CustomerId",
                table: "Products",
                newName: "IX_Products_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Part_StorageId",
                table: "Parts",
                newName: "IX_Parts_StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_WorkerId",
                table: "Orders",
                newName: "IX_Orders_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ProductId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomService_WorkerId",
                table: "CustomServices",
                newName: "IX_CustomServices_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomService_ServiceId",
                table: "CustomServices",
                newName: "IX_CustomServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomService_PartId",
                table: "CustomServices",
                newName: "IX_CustomServices_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomService_OrderId",
                table: "CustomServices",
                newName: "IX_CustomServices_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomServices",
                table: "CustomServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Orders_OrderId",
                table: "CustomServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Services_ServiceId",
                table: "CustomServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomServices_Workers_WorkerId",
                table: "CustomServices",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workers_WorkerId",
                table: "Orders",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Models_ModelId",
                table: "Storages",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Workers_WorkerId",
                table: "Storages",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Orders_OrderId",
                table: "CustomServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Parts_PartId",
                table: "CustomServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Services_ServiceId",
                table: "CustomServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomServices_Workers_WorkerId",
                table: "CustomServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workers_WorkerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Models_ModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Models_ModelId",
                table: "Storages");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Workers_WorkerId",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomServices",
                table: "CustomServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Part");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "CustomServices",
                newName: "CustomService");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Storages_WorkerId",
                table: "Storage",
                newName: "IX_Storage_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Storages_ModelId",
                table: "Storage",
                newName: "IX_Storage_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ModelId",
                table: "Product",
                newName: "IX_Product_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CustomerId",
                table: "Product",
                newName: "IX_Product_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_StorageId",
                table: "Part",
                newName: "IX_Part_StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_WorkerId",
                table: "Order",
                newName: "IX_Order_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Order",
                newName: "IX_Order_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomServices_WorkerId",
                table: "CustomService",
                newName: "IX_CustomService_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomServices_ServiceId",
                table: "CustomService",
                newName: "IX_CustomService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomServices_PartId",
                table: "CustomService",
                newName: "IX_CustomService_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomServices_OrderId",
                table: "CustomService",
                newName: "IX_CustomService_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomService",
                table: "CustomService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomService_Order_OrderId",
                table: "CustomService",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomService_Part_PartId",
                table: "CustomService",
                column: "PartId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomService_Service_ServiceId",
                table: "CustomService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomService_Workers_WorkerId",
                table: "CustomService",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Workers_WorkerId",
                table: "Order",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Storage_StorageId",
                table: "Part",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Customer_CustomerId",
                table: "Product",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Model_ModelId",
                table: "Product",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Model_ModelId",
                table: "Storage",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Workers_WorkerId",
                table: "Storage",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
