using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace final_project.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    parent_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_parent_id",
                        column: x => x.parent_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_methods",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fullname = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    role = table.Column<int>(nullable: false),
                    permission = table.Column<bool>(nullable: false),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    sandbox = table.Column<string>(nullable: true),
                    production = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    shop_name = table.Column<string>(nullable: true),
                    payment_account = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sandbox = table.Column<string>(nullable: true),
                    production = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shops_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Check_Paid_Shops",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    date_expired = table.Column<DateTime>(nullable: false),
                    date_paid = table.Column<DateTime>(nullable: false),
                    money = table.Column<int>(nullable: false),
                    shop_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check_Paid_Shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Check_Paid_Shops_Shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    date_create = table.Column<DateTime>(nullable: false),
                    date_paid = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    payment_id = table.Column<string>(nullable: true),
                    receiver_id = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    shop_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Payment_methods_payment_id",
                        column: x => x.payment_id,
                        principalTable: "Payment_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Receivers_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "Receivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    product_name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    cat_id = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    shop_id = table.Column<string>(nullable: true),
                    permission = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_cat_id",
                        column: x => x.cat_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    contents = table.Column<string>(nullable: true),
                    product_id = table.Column<string>(nullable: true),
                    rate = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    order_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_details_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_details_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_Colors",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    product_id = table.Column<string>(nullable: true),
                    color_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Colors", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_Colors_Colors_color_id",
                        column: x => x.color_id,
                        principalTable: "Colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_Colors_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "name", "parent_id" },
                values: new object[,]
                {
                    { "1", "Chăm sóc da", "1" },
                    { "2", "Trang điểm", "2" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { "1", "Đỏ" },
                    { "2", "Hồng" },
                    { "3", "Trắng" },
                    { "4", "Đen" }
                });

            migrationBuilder.InsertData(
                table: "Payment_methods",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { "1", "Thanh toán khi nhận hàng" },
                    { "2", "Paypal" }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "id", "address", "email", "fullname", "phone" },
                values: new object[,]
                {
                    { "8", "193 NLB", "damhoangbuu@gmail.com", "Đàm Văn Hoàng Bửu", "0898237228" },
                    { "7", "193 NLB", "damhoangbuu@gmail.com", "Đàm Văn Hoàng Bửu", "0898237228" },
                    { "6", "193 NLB", "damhoangbuu@gmail.com", "Đàm Văn Hoàng Bửu", "0898237228" },
                    { "5", "193 NLB", "damhoangbuu@gmail.com", "Đàm Văn Hoàng Bửu", null },
                    { "3", "193 NLB", "tranthusuong@gmail.com", "Trần Thu Sương", "0975197462" },
                    { "2", "193 NLB", "buithikieu@gmail.com", "Bùi Thị Kiều", "0975191672" },
                    { "1", "193 NLB", "damhoangbuu@gmail.com", "Đàm Văn Hoàng Bửu", "0898237228" },
                    { "4", "193 NLB", "nguyentruongson@gmail.com", "Nguyễn Trường Sơn", "0988191672" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "address", "email", "password", "permission", "phone", "role", "user_name" },
                values: new object[,]
                {
                    { "8", "193 NLB", "nguyentruongson@gmail.com", "123456", true, "0898237228", 2, "Nguyễn Trường Sơn" },
                    { "1", "193 NLB", "damhoangbuu@gmail.com", "123456", true, "0898237228", 1, "Đàm Văn Hoàng Bửu" },
                    { "2", "193 NLB", "buithikieu@gmail.com", "123456", true, "0898237228", 2, "Bùi Thị Kiều" },
                    { "3", "193 NLB", "tranthusuong@gmail.com", "123456", true, "0898237228", 3, "Trần Thu Sương" },
                    { "4", "193 NLB", "tranphuquy@gmail.com", "123456", true, "0898237228", 3, "Trần Phú Quy" },
                    { "5", "193 NLB", "tranchivi@gmail.com", "123456", true, "0898237228", 3, "Trần Chí Vĩ" },
                    { "6", "193 NLB", "trananhthu@gmail.com", "123456", true, "0898237228", 3, "Trần Thị Anh Thư" },
                    { "7", "193 NLB", "votuonghuan@gmail.com", "123456", true, "0898237228", 2, "Võ Tường Huân" }
                });

            migrationBuilder.InsertData(
                table: "Websites",
                columns: new[] { "id", "address", "email", "phone", "production", "sandbox" },
                values: new object[] { "1", "Núi Thành,Quảng Nam", "buithikieu16tclc3@gmail", "0372751805", "AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr", "AYYYpz6WNLv_ibeOkju_7uX2SM1NWRmTd3VrE-HEu7UuXEdvSvQ1vLGUS6upj9TIGV_Cv_wTfG8fZo6O" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "name", "parent_id" },
                values: new object[,]
                {
                    { "3", "Chống nắng", "1" },
                    { "4", "Dưỡng ẩm", "1" },
                    { "5", "Mặt nạ", "1" },
                    { "6", "Nước hoa hồng", "1" },
                    { "7", "Tinh chất dưỡng", "1" },
                    { "8", "Chăm sóc môi", "2" },
                    { "9", "Kem nền", "2" },
                    { "10", "Mascara", "2" },
                    { "11", "Phấn phủ", "2" },
                    { "12", "Son", "2" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "id", "address", "email", "payment_account", "production", "sandbox", "shop_name", "user_id" },
                values: new object[,]
                {
                    { "1", "193 NLB", "buithikieu@gmail.com", "abcxyz", "AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr", "AflZ3L1sfI6M45m8x1OvqF-cLAPO2uWwfQTkTiwqdNrgS-RTQhjuAYqXJYOHDHxW82G_lPur_gGkz2eC", "Shop mỹ phẩm bà Kèo", "2" },
                    { "2", "194 NLB", "votuonghuan@gmail.com", "abcxyz", "AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr", "AaWOS3eowQdRfXGojWXfp15QEgw4ylIUYw5iittDOOde9XYNAsrwjYW9236KebkAF_FeKR30t4fCjp7w", "Ông Huân Vlog", "7" },
                    { "3", "195 NLB", "nguyentruongson@gmail.com", "abcxyz", "AakS9m2vudatyxfs7xLTHAiA_oEgZ5h7lK8D6JlhTOUv24riXWap8bTK5fatuvlLVsnQ1TVX8Lm55zVr", "AQk3ajkq4FqLtnXsIliLZ1NZzAHKWJzR70yMQdTfTg_8EbfBrmCJ44Bby1_cVkzFpwsEibf8uu3xGuSS", "Bé Sơn Parody", "8" }
                });

            migrationBuilder.InsertData(
                table: "Check_Paid_Shops",
                columns: new[] { "id", "date_expired", "date_paid", "money", "shop_id" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000, "1" },
                    { "2", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000, "2" },
                    { "3", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000, "3" },
                    { "4", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000, "3" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "date_create", "date_paid", "payment_id", "receiver_id", "shop_id", "status", "total", "user_id" },
                values: new object[,]
                {
                    { "1", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "1", "1", 1, 900000, "1" },
                    { "2", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "3", "1", 2, 800000, "3" },
                    { "3", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "4", "1", 3, 1000000, "4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "cat_id", "description", "image", "permission", "price", "product_name", "quantity", "shop_id" },
                values: new object[,]
                {
                    { "29", "9", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "KemNen4.jpg", true, 700000, "Kem Nền Che Phủ Hoàn Hảo, Giúp Da Bóng Khỏe, Rạng Rỡ Suốt 24 Tiếng Etude House Double Lasting Serum Foundation SPF25 PA++", 100, "2" },
                    { "32", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara.jpg", true, 100000, "Mascara Siêu Dày Mi Innisfree Super Volumecara ", 100, "2" },
                    { "35", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara4.jpg", true, 180000, "Mascara Giúp Dài Mi Chống Trôi Missha Length Boost Cara", 100, "2" },
                    { "38", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu2.jpg", true, 340000, "Phấn phủ LANEIGE", 100, "2" },
                    { "41", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu5.jpg", true, 450000, "Phấn Phủ Dạng Nén Kiềm Dầu, Che Phủ Lỗ Chân Lông A'pieu Oil Control Film Pact", 100, "2" },
                    { "44", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "SonThoi.jpg", true, 850000, "Son Thỏi Lì ROM", 100, "2" },
                    { "47", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Son3.jpg", true, 370000, "Son Kem Lì Black Rouge Air Fit Velvet", 100, "2" },
                    { "7", "3", "Giúp làm dịu da, kháng viêm, giảm kích ứng da ngay lần đầu sử dụng.", "ChongNang7.jpg", true, 1000000, "Kem Chống Nắng Chiết Xuất Măng Cụt It's Skin Tropical Sun Gel Mangosteen SPF50+/PA++++ ", 50, "3" },
                    { "8", "3", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "ChongNang8.jpg", true, 1500000, "Xịt Chống Nắng Làm Dịu Da Giảm Nhiệt Tức Thì Mediheal Labocare Ceramatica Sun Spray", 50, "3" },
                    { "12", "5", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "MatNaDatSet.jpg", true, 400000, "Mặt nạ dưỡng da đất sét", 100, "3" },
                    { "26", "9", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "KemNen1.jpg", true, 670000, "Kem nền Innisfree", 100, "2" },
                    { "14", "5", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "MatNa1.jpg", true, 300000, "Mặt Nạ Vitamin Dưỡng Trắng Da By Wishtrend Natural Vitamin 21.5% Enhancing Sheet Mask", 100, "3" },
                    { "16", "5", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "MatNa4.jpg", true, 270000, "Mặt Nạ Ngủ Dưỡng Trắng Chiết Xuất Từ Trái Thanh Yên Some By Mi Yuja Niacin 30 Days Miracle Brightening Sleeping Mask", 100, "3" },
                    { "22", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "DuongMoi2.jpg", true, 810000, "Son Dưỡng Môi Có Màu Innisfree Glow Tint Lip Balm", 100, "3" },
                    { "27", "9", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "KemNen2.jpg", true, 100000, "Kem nền Power Perfection BB cream", 100, "3" },
                    { "30", "9", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "KemNen5.jpg", true, 300000, "Kem Nền Che Phủ Tốt, Lâu Trôi I'm Meme I'm Genius Foundation All Cover", 100, "3" },
                    { "31", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara1.jpg", true, 200000, "Mascara Làm Dày Mi Không Lem Missha 4D Mascara", 100, "3" },
                    { "36", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara5.jpg", true, 210000, "Mascara Chống Trôi , Làm Cong Mi Tự Nhiên Shionle Fixing High Heel Cara", 100, "3" },
                    { "39", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu3.jpg", true, 290000, "Phấn Phủ Bột Kiềm Dầu Innisfree No Sebum Mineral Powder", 100, "3" },
                    { "42", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu6.jpg", true, 290000, "Phấn Phủ Kiềm Dầu I'm Meme I'm Oil Cut Pact ", 100, "3" },
                    { "45", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Son1.jpg", true, 350000, "Son Kem Lì Black Rouge Air Fit Velvet Tint", 100, "3" },
                    { "11", "4", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "DuongAm.jpg", true, 600000, "Kem Dưỡng Ẩm Và Giữ Ẩm Chuyên Sâu Với Chiết Xuất Từ Gừng Và Mật Ong Innisfree Ginger Honey Cream", 100, "3" },
                    { "24", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "DuongMoi4.jpg", true, 920000, "Mặt Nạ Ngủ Môi Carenel Berry Lip Night Mask", 100, "2" },
                    { "19", "6", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "NuocHoaHong2.jpg", true, 900000, "Nước hoa hồng Tea Tree Cica", 100, "2" },
                    { "48", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Son4.jpg", true, 800000, "Son Tint Lì Lâu Trôi Black Rouge Power Proof Matte Tint ", 100, "3" },
                    { "1", "3", "Kem trang điểm chống nắng Innisfree SPF50+ PA++++ được rất nhiều chị em trên khắp thế giới yêu thích là bởi chất kem nhẹ bẫng, mềm mượt, tạo nên một lớp trang điểm hoàn hảo mà vẫn có chỉ số chống nắng cao ngất ngưởng, có thể bảo vệ làn da tuyệt đối dưới ánh nắng mặt trời ngày hè", "ChongNang1.jpg", true, 900000, "Kem chống nắng Innisfree SPF50+ PA++++", 100, "1" },
                    { "2", "3", "Có khả năng bảo vệ da mạnh mẽ dưới tác động của ánh nắng mặt trời, cung cấp độ ẩm cho da, làn da trắng hồng rạng rỡ, đầy sức sống", "ChongNang3.jpg", true, 800000, "Kem Chống Nắng Dịu Nhẹ Với Chiết xuất Từ Thiên Nhiên Black Rouge Cica Green Sun Cream SPF50+/PA++++", 150, "1" },
                    { "3", "3", "Kem chống nắng vật lý, chăm sóc da mẫn cảm, dưỡng trắng", "ChongNang2.jpg", true, 1000000, "Kem chống nắng Uriage Bariesun SPF50+ - Kem chống nắng tốt nhất giúp tái tạo da và ngừa da hư tổn", 50, "1" },
                    { "4", "3", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "ChongNang4.jpg", true, 1500000, "Kem chống nắng kiêm kem lót nâng tone da A'pieu Pure Block Tone-Up Sun Base SPF50+ PA+++", 50, "1" },
                    { "9", "4", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "DuongAmSau.jpg", true, 450000, "Serum  dưỡng ẩm Innisfree", 100, "1" },
                    { "15", "5", "Táo được biết đến là top thực phẩm giàu chất chống oxy hóa, giúp ngăn quá trình lão hóa", "MatNa2.jpg", true, 500000, "Mặt Nạ Làm Sáng Da, Loại Bỏ Tế Bào Chết Chiết Xuất Từ TáoROUNDLAB Apple Peeling Mask ", 100, "1" },
                    { "18", "6", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "NuocHoaHong1.jpg", true, 820000, "Nước hoa hồng Innisfree", 100, "1" },
                    { "20", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "ChamSocMoi2.jpg", true, 210000, "Son Dưỡng Môi Innisfree", 100, "1" },
                    { "23", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "DuongMoi3.jpg", true, 170000, "Son Dưỡng 16Brand Fruit Chu Petit Lip Balm", 100, "1" },
                    { "25", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "DuongMoi5.jpg", true, 280000, "Mặt Nạ Ngủ Môi Chiết Xuất Rau Má A'pieu Madecassoside Lip Sleeping Mask 20g", 100, "1" },
                    { "28", "9", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "KemNen3.jpg", true, 800000, "Kem Nền Siêu Lì, Lâu Trôi A'pieu BB Maker Long Wear SPF30 PA+++", 100, "1" },
                    { "33", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara2.jpg", true, 150000, "Mascara Chân Mày Missha Color Wear Browcara", 100, "1" },
                    { "34", "10", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Mascara3.jpg", true, 350000, "Mascara Chuốt Mi Cong Vút Tự Nhiên, Chống Trôi Etude House Lash Perm Curl Fix Mascara", 100, "1" },
                    { "37", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu1.jpg", true, 230000, "Phấn phủ Play 101 Setting", 100, "1" },
                    { "40", "11", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "PhanPhu4.jpg", true, 320000, "Phấn Phủ Bột Kiềm Dầu, Cố Định Lớp Makeup A'pieu Mineral 100 HD Powder", 100, "1" },
                    { "43", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "SonLi.jpg", true, 430000, "Son Thỏi Lì Merzy The First Lipstick", 100, "1" },
                    { "46", "12", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Son2.jpg", true, 210000, "Son kem lì cực nhẹ môi Romand Zero Velvet Tint", 100, "1" },
                    { "50", "3", "Kem trang điểm chống nắng Innisfree SPF50+ PA++++ được rất nhiều chị em trên khắp thế giới yêu thích là bởi chất kem nhẹ bẫng, mềm mượt, tạo nên một lớp trang điểm hoàn hảo mà vẫn có chỉ số chống nắng cao ngất ngưởng, có thể bảo vệ làn da tuyệt đối dưới ánh nắng mặt trời ngày hè", "ChongNang1.jpg", true, 900000, "Kem chống nắng Innisfree SPF50+ PA++++", 100, "1" },
                    { "5", "3", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "ChongNang5.jpg", true, 900000, "Kem Chống Nắng Dạng Gel Chống Tia Hồng Ngoại, Giảm Nhiệt Độ Tức Thì Make Prem UV Defense Me Blue Ray Sun Gel SPF50/PA++++", 100, "2" },
                    { "6", "3", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "ChongNang6.jpg", true, 800000, " Kem Chống Nắng Dưỡng Trắng Da Milky Dress Aqua Sun Cream", 150, "2" },
                    { "10", "4", "Sản phẩm đến từ Hàn Quốc chất lượng cao", "DuongAmSauDanHoi.jpg", true, 700000, "Serum dưỡng ẩm đàn hồi Innisfree", 100, "2" },
                    { "13", "5", "Không chỉ là loại quả bổ dưỡng, cam còn có tác dụng làm đẹp da tuyệt vời và lành tính nhất. Cam chứa nhiều vitamin A, B, E, Kali…giúp cung cấp dưỡng chất nuôi dưỡng da. Đồng thời cam cung cấp độ ẩm cho da giúp da khỏe mạnh và đàn hồi tốt", "MatNaCam.jpg", true, 900000, "Mặt nạ dưỡng da từ quả Cam", 100, "2" },
                    { "17", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "MatNa3.jpg", true, 200000, "Mặt Nạ Ngủ Môi Laneige Lip Sleeping Mask", 100, "2" },
                    { "21", "8", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "DuongMoi1.jpg", true, 110000, "Son Dưỡng Innisfree Canola Honey Lip Balm", 100, "2" },
                    { "49", "7", "Sản phẩm chất lượng cao đến từ Hàn Quốc", "Tinhchat.jpg", true, 800000, "Tinh chất dưỡng ", 100, "3" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "id", "contents", "product_id", "rate", "user_id" },
                values: new object[,]
                {
                    { "1", "Đồ cùi quá", "1", 3, "1" },
                    { "16", "Oke", "11", 1, "4" },
                    { "12", "Oke", "7", 1, "4" },
                    { "10", "Oke", "5", 1, "4" },
                    { "14", "Oke", "9", 1, "4" },
                    { "11", "Oke", "6", 1, "4" },
                    { "9", "Oke", "4", 1, "4" },
                    { "8", "Oke", "3", 5, "4" },
                    { "15", "Oke", "10", 1, "4" },
                    { "13", "Oke", "8", 1, "4" },
                    { "7", "Oke", "2", 5, "3" },
                    { "6", "Oke", "2", 4, "2" },
                    { "5", "Đồ cùi quá", "2", 3, "1" },
                    { "4", "Oke", "1", 5, "4" },
                    { "3", "Oke", "1", 5, "3" },
                    { "2", "Oke", "1", 4, "2" }
                });

            migrationBuilder.InsertData(
                table: "Order_details",
                columns: new[] { "id", "order_id", "price", "product_id", "quantity" },
                values: new object[,]
                {
                    { "1", "1", 900000, "1", 1 },
                    { "2", "2", 800000, "2", 1 },
                    { "3", "3", 1000000, "3", 1 }
                });

            migrationBuilder.InsertData(
                table: "product_Colors",
                columns: new[] { "id", "color_id", "product_id" },
                values: new object[,]
                {
                    { "7", "3", "7" },
                    { "31", "3", "38" },
                    { "28", "4", "29" },
                    { "34", "3", "41" },
                    { "37", "1", "44" },
                    { "40", "2", "47" },
                    { "16", "3", "16" },
                    { "11", "3", "11" },
                    { "12", "3", "12" },
                    { "14", "3", "14" },
                    { "25", "4", "26" },
                    { "21", "2", "22" },
                    { "26", "4", "27" },
                    { "29", "4", "30" },
                    { "32", "3", "39" },
                    { "35", "3", "42" },
                    { "8", "3", "8" },
                    { "23", "2", "24" },
                    { "5", "3", "5" },
                    { "18", "2", "19" },
                    { "1", "3", "1" },
                    { "2", "3", "2" },
                    { "3", "3", "3" },
                    { "4", "3", "4" },
                    { "9", "3", "9" },
                    { "15", "3", "15" },
                    { "17", "1", "18" },
                    { "19", "1", "20" },
                    { "22", "1", "23" },
                    { "20", "1", "21" },
                    { "24", "4", "25" },
                    { "30", "3", "37" },
                    { "33", "3", "40" },
                    { "36", "1", "43" },
                    { "39", "2", "46" },
                    { "42", "1", "50" },
                    { "38", "2", "45" },
                    { "6", "3", "6" },
                    { "10", "3", "10" },
                    { "13", "3", "13" },
                    { "27", "4", "28" },
                    { "41", "1", "48" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_parent_id",
                table: "Categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Paid_Shops_shop_id",
                table: "Check_Paid_Shops",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_product_id",
                table: "Comments",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_order_id",
                table: "Order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_product_id",
                table: "Order_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_payment_id",
                table: "Orders",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_receiver_id",
                table: "Orders",
                column: "receiver_id",
                unique: true,
                filter: "[receiver_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_shop_id",
                table: "Orders",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_Colors_color_id",
                table: "product_Colors",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_Colors_product_id",
                table: "product_Colors",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_cat_id",
                table: "Products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_shop_id",
                table: "Products",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_user_id",
                table: "Shops",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Check_Paid_Shops");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "product_Colors");

            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Payment_methods");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
