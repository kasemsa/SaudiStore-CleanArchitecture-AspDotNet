using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudiStore.Persistence.Migrations
{
    public partial class InitMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Inverters" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Batteries" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Solar Panel" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3129), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3116), 85, new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c") },
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3072), 400, new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b") },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3102), 135, new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340") },
                    { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3230), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3142), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2023, 11, 18, 21, 2, 16, 676, DateTimeKind.Local).AddTicks(3156), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CompanyName", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0d6bbaf4-895a-4cfe-820e-f2f029837ee5"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "CHNT", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "circuit breaker 50A Double", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSX4hjn4j-STAM068jOAFmnqUsIIrBNXhpbyUuReigg02HAPJr3pxH8KG50SuxfH3xLMKI&usqp=CAU", null, null, "circuit breaker", 1200 },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Voltronic Power", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPS 5000W", "https://voltronicpower.com/Content/images/product/20200214102525.jpg", null, null, "UPS 5000W", 1200 },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Deye", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithium-ion Battery 100A , 24V ", "https://toplakuca.me/wp-content/uploads/2023/01/lithium-battery-deye-se-g5.1-100ah-51.2v-1.webp", null, null, "Lithium-ion Battery", 1500 },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Voltronic Power", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPS 3500W", "https://voltronicpower.com/Content/images/product/20200214102525.jpg", null, null, "UPS 3500W", 1200 },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "SAKO", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solar Panel 550W", "https://sakopower.com/wp-content/uploads/2022/05/550w%E5%A4%AA%E9%98%B3%E8%83%BD%E6%9D%BF-%E4%B8%BB%E5%9B%BE-5-2.jpg", null, null, "Solar Panel 550W", 1200 },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Nova", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithium-ion Battery 200A , 24V ", "https://www.nova-ess.com/wp-content/uploads/2022/08/4-1-300x159.png", null, null, "Lithium-ion Battery", 1200 },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Deye", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithium-ion Battery 200A , 51.2V ", "https://toplakuca.me/wp-content/uploads/2023/01/lithium-battery-deye-se-g5.1-100ah-51.2v-1.webp", null, null, "Lithium-ion Battery", 2000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
