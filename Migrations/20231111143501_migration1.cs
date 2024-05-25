using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_Phòng_Trọ.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: false),
                    Phone = table.Column<string>(type: "nchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<byte>(type: "tinyint", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<long>(type: "bigint", nullable: false),
                    CCCD = table.Column<string>(type: "nchar(12)", maxLength: 12, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantID);
                    table.ForeignKey(
                        name: "FK_Tenants_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<long>(type: "bigint", nullable: false),
                    StaffID = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_Contracts_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryInvoices",
                columns: table => new
                {
                    HistoryInvoicesID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<long>(type: "bigint", nullable: false),
                    PayDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryInvoices", x => x.HistoryInvoicesID);
                    table.ForeignKey(
                        name: "FK_HistoryInvoices_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    ServiceDetailID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceID = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.ServiceDetailID);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Area", "RoomName", "RoomPrice", "Status" },
                values: new object[,]
                {
                    { 1L, 5m, "Phòng 101", 1500000m, false },
                    { 2L, 10m, "Phòng 102", 3000000m, true },
                    { 3L, 15m, "Phòng 103", 4500000m, false },
                    { 4L, 30m, "Phòng 104", 55000000m, true },
                    { 5L, 12m, "Phòng 105", 35000000m, false },
                    { 6L, 7m, "Phòng 106", 2000000m, false }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "CreateDate", "ImageFile", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000m, "Điện" },
                    { 2L, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5000m, "Nước" },
                    { 3L, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50000m, "Rác thải" },
                    { 4L, new DateTime(2001, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 220000m, "Internet" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffID", "Address", "Avatar", "Birthday", "Email", "Gender", "Password", "Phone", "RoleID", "StaffName", "Status" },
                values: new object[,]
                {
                    { 1L, "Quận Tân Bình, TP.HCM", null, new DateTime(2003, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2154810035@vaa.edu.vn", true, "password", "1234567890", (byte)1, "Phát", true },
                    { 2L, "Quận Thủ Đức, TP.HCM", null, new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2154810027@vaa.edu.vn", true, "password", "1234567890", (byte)1, "Minh", true },
                    { 3L, "Quận Tân Bình, TP.HCM", null, new DateTime(2003, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2154810045@vaa.edu.vn", true, "password", "1234567890", (byte)1, "Dũng", true },
                    { 4L, "Quận 5, TP.HCM", null, new DateTime(2003, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2154810015@vaa.edu.vn", false, "password", "1234567890", (byte)3, "Trúc Shiba Bếu", true },
                    { 5L, "Quận Tân Phú, TP.HCM", null, new DateTime(2003, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2154810103@vaa.edu.vn", null, "password", "1234567890", (byte)2, "Bảo", true }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractID", "CreateDate", "EndDate", "RoomID", "StaffID", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 2L, true, 3000000m },
                    { 2L, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 4L, true, 55000000m }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "CreateDate", "EndDate", "RoomID", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, true, 1900000m },
                    { 2L, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, true, 4000000m }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantID", "Address", "Birthday", "CCCD", "FullName", "Gender", "JoinDate", "RoomID" },
                values: new object[,]
                {
                    { 1L, "Sao Mộc, Ngân hà dũ trụ", new DateTime(2003, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "072307489013", "Shiba Bếu", false, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 2L, "Quận Sao Kim, TP.Mộc Tinh", new DateTime(2003, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "075307592016", "Minh Ẩn Danh", true, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L }
                });

            migrationBuilder.InsertData(
                table: "HistoryInvoices",
                columns: new[] { "HistoryInvoicesID", "InvoiceID", "PayDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetails",
                columns: new[] { "ServiceDetailID", "InvoiceID", "Quantity", "ServiceID", "TotalAmount" },
                values: new object[,]
                {
                    { 1L, 1L, 12, 1L, 3000m },
                    { 2L, 1L, 15, 2L, 5000m },
                    { 3L, 2L, 26, 1L, 3000m },
                    { 4L, 2L, 10, 2L, 5000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RoomID",
                table: "Contracts",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_StaffID",
                table: "Contracts",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryInvoices_InvoiceID",
                table: "HistoryInvoices",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RoomID",
                table: "Invoices",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_InvoiceID",
                table: "ServiceDetails",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceID",
                table: "ServiceDetails",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RoomID",
                table: "Tenants",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "HistoryInvoices");

            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
