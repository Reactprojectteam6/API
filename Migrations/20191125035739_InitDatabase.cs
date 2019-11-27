using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace final_project.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    parent_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_categories_categories_parent_id",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    user_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    admin = table.Column<bool>(nullable: false),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    payment_accont = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_shops_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Check_paid_shop",
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
                    table.PrimaryKey("PK_Check_paid_shop", x => x.id);
                    table.ForeignKey(
                        name: "FK_Check_paid_shop_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    product_name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    cat_id = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    shop_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_cat_id",
                        column: x => x.cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_shops_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    contents = table.Column<string>(nullable: true),
                    product_id = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    product_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.id);
                    table.ForeignKey(
                        name: "FK_Picture_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    order_id = table.Column<string>(nullable: true),
                    size_id = table.Column<string>(nullable: true),
                    color_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_details_colors_color_id",
                        column: x => x.color_id,
                        principalTable: "colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_details_sizes_size_id",
                        column: x => x.size_id,
                        principalTable: "sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recievers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fullname = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    order_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recievers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    date_create = table.Column<DateTime>(nullable: false),
                    date_paid = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    total = table.Column<int>(nullable: false),
                    payment_id = table.Column<string>(nullable: true),
                    reciever_id = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_payment_methods_payment_id",
                        column: x => x.payment_id,
                        principalTable: "payment_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_recievers_reciever_id",
                        column: x => x.reciever_id,
                        principalTable: "recievers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_id",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_paid_shop_shop_id",
                table: "Check_paid_shop",
                column: "shop_id",
                unique: true,
                filter: "[shop_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_comments_product_id",
                table: "comments",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_color_id",
                table: "order_details",
                column: "color_id",
                unique: true,
                filter: "[color_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_order_id",
                table: "order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_product_id",
                table: "order_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_size_id",
                table: "order_details",
                column: "size_id",
                unique: true,
                filter: "[size_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_payment_id",
                table: "Orders",
                column: "payment_id",
                unique: true,
                filter: "[payment_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_reciever_id",
                table: "Orders",
                column: "reciever_id",
                unique: true,
                filter: "[reciever_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_product_id",
                table: "Picture",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_cat_id",
                table: "products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_shop_id",
                table: "products",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_recievers_order_id",
                table: "recievers",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_shops_user_id",
                table: "shops",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_order_details_Orders_order_id",
                table: "order_details",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_recievers_Orders_order_id",
                table: "recievers",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_users_user_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_recievers_Orders_order_id",
                table: "recievers");

            migrationBuilder.DropTable(
                name: "Check_paid_shop");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "recievers");
        }
    }
}
