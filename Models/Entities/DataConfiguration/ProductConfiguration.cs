

using System;
using final_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace final_project.Models.Entities.DataConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product{
                    id = "1",
                    product_name = "Kem chống nắng Innisfree SPF50+ PA++++",
                    description = "Kem trang điểm chống nắng Innisfree SPF50+ PA++++ được rất nhiều chị em trên khắp thế giới yêu thích là bởi chất kem nhẹ bẫng, mềm mượt, tạo nên một lớp trang điểm hoàn hảo mà vẫn có chỉ số chống nắng cao ngất ngưởng, có thể bảo vệ làn da tuyệt đối dưới ánh nắng mặt trời ngày hè",
                    cat_id = "3",
                    price = 900000,
                    quantity = 100,
                    shop_id = "1",
                    image = "ChongNang1.jpg"
                },
                new Product{
                    id = "2",
                    product_name = "Kem Chống Nắng Dịu Nhẹ Với Chiết xuất Từ Thiên Nhiên Black Rouge Cica Green Sun Cream SPF50+/PA++++",
                    description = "Có khả năng bảo vệ da mạnh mẽ dưới tác động của ánh nắng mặt trời, cung cấp độ ẩm cho da, làn da trắng hồng rạng rỡ, đầy sức sống",
                    cat_id = "3",
                    price = 800000,
                    quantity = 150,
                    shop_id = "1",
                    image = "ChongNang3.jpg"
                },
                new Product{
                    id = "3",
                    product_name = "Kem chống nắng Uriage Bariesun SPF50+ - Kem chống nắng tốt nhất giúp tái tạo da và ngừa da hư tổn",
                    description="Kem chống nắng vật lý, chăm sóc da mẫn cảm, dưỡng trắng",
                    cat_id = "3",
                    price = 1000000,
                    quantity = 50,
                    shop_id = "1",
                    image = "ChongNang2.jpg"
                },
                new Product{
                    id = "4",
                    product_name = "Kem chống nắng kiêm kem lót nâng tone da A'pieu Pure Block Tone-Up Sun Base SPF50+ PA+++",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "3",
                    price = 1500000,
                    quantity = 50,
                    shop_id = "1",
                    image = "ChongNang4.jpg"
                },
                new Product{
                    id = "5",
                    product_name = "Kem Chống Nắng Dạng Gel Chống Tia Hồng Ngoại, Giảm Nhiệt Độ Tức Thì Make Prem UV Defense Me Blue Ray Sun Gel SPF50/PA++++",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "3",
                    price = 900000,
                    quantity = 100,
                    shop_id = "2",
                    image = "ChongNang5.jpg"
                },
                new Product{
                    id = "6",
                    product_name = " Kem Chống Nắng Dưỡng Trắng Da Milky Dress Aqua Sun Cream",
                     description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "3",
                    price = 800000,
                    quantity = 150,
                    shop_id = "2",
                    image = "ChongNang6.jpg"
                },
                new Product{
                    id = "7",
                    product_name = "Kem Chống Nắng Chiết Xuất Măng Cụt It's Skin Tropical Sun Gel Mangosteen SPF50+/PA++++ ",
                    description = "Giúp làm dịu da, kháng viêm, giảm kích ứng da ngay lần đầu sử dụng.",
                    cat_id = "3",
                    price = 1000000,
                    quantity = 50,
                    shop_id = "3",
                    image = "ChongNang7.jpg"
                },
                new Product{
                    id = "8",
                    product_name = "Xịt Chống Nắng Làm Dịu Da Giảm Nhiệt Tức Thì Mediheal Labocare Ceramatica Sun Spray",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "3",
                    price = 1500000,
                    quantity = 50,
                    shop_id = "3",
                    image = "ChongNang8.jpg"
                },
                new Product{
                    id = "9",
                    product_name = "Serum  dưỡng ẩm Innisfree",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "4",
                    price = 450000,
                    quantity = 100,
                    shop_id = "1",
                    image="DuongAmSau.jpg"
                },
                new Product{
                    id = "10",
                    product_name = "Serum dưỡng ẩm đàn hồi Innisfree",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "4",
                    price = 700000,
                    quantity = 100,
                    shop_id = "2",
                    image="DuongAmSauDanHoi.jpg"
                },
                new Product{
                    id = "11",
                    product_name = "Kem Dưỡng Ẩm Và Giữ Ẩm Chuyên Sâu Với Chiết Xuất Từ Gừng Và Mật Ong Innisfree Ginger Honey Cream",
                    description="Sản phẩm đến từ Hàn Quốc chất lượng cao",
                    cat_id = "4",
                    price = 600000,
                    quantity = 100,
                    shop_id = "3",
                    image="DuongAm.jpg"
                },
                new Product{
                    id = "12",
                    product_name = "Mặt nạ dưỡng da đất sét",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "5",
                    price = 400000,
                    quantity = 100,
                    shop_id = "3",
                    image="MatNaDatSet.jpg"
                },
                new Product{
                    id = "13",
                    product_name = "Mặt nạ dưỡng da từ quả Cam",
                    description = "Không chỉ là loại quả bổ dưỡng, cam còn có tác dụng làm đẹp da tuyệt vời và lành tính nhất. Cam chứa nhiều vitamin A, B, E, Kali…giúp cung cấp dưỡng chất nuôi dưỡng da. Đồng thời cam cung cấp độ ẩm cho da giúp da khỏe mạnh và đàn hồi tốt",
                    cat_id = "5",
                    price = 900000,
                    quantity = 100,
                    shop_id = "2",
                    image="MatNaCam.jpg"
                },
                new Product{
                    id = "14",
                    product_name = "Mặt Nạ Vitamin Dưỡng Trắng Da By Wishtrend Natural Vitamin 21.5% Enhancing Sheet Mask",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "5",
                    price = 300000,
                    quantity = 100,
                    shop_id = "3",
                    image="MatNa1.jpg"
                },
                new Product{
                    id = "15",
                    product_name = "Mặt Nạ Làm Sáng Da, Loại Bỏ Tế Bào Chết Chiết Xuất Từ TáoROUNDLAB Apple Peeling Mask ",
                    description = "Táo được biết đến là top thực phẩm giàu chất chống oxy hóa, giúp ngăn quá trình lão hóa",
                    cat_id = "5",
                    price = 500000,
                    quantity = 100,
                    shop_id = "1",
                    image="MatNa2.jpg"
                },
                new Product{
                    id = "16",
                    product_name = "Mặt Nạ Ngủ Dưỡng Trắng Chiết Xuất Từ Trái Thanh Yên Some By Mi Yuja Niacin 30 Days Miracle Brightening Sleeping Mask",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "5",
                    price = 270000,
                    quantity = 100,
                    shop_id = "3",
                    image="MatNa4.jpg"
                },
                new Product{
                    id = "17",
                    product_name = "Mặt Nạ Ngủ Môi Laneige Lip Sleeping Mask",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 200000,
                    quantity = 100,
                    shop_id = "2",
                    image="MatNa3.jpg"
                },
                new Product{
                    id = "18",
                    product_name = "Nước hoa hồng Innisfree",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "6",
                    price = 820000,
                    quantity = 100,
                    shop_id = "1",
                    image="NuocHoaHong1.jpg"
                },
                new Product{
                    id = "19",
                    product_name = "Nước hoa hồng Tea Tree Cica",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "6",
                    price = 900000,
                    quantity = 100,
                    shop_id = "2",
                    image="NuocHoaHong2.jpg"
                },
                new Product{
                    id = "20",
                    product_name = "Son Dưỡng Môi Innisfree",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 210000,
                    quantity = 100,
                    shop_id = "1",
                    image="ChamSocMoi2.jpg"
                },  
                new Product{
                    id = "21",
                    product_name = "Son Dưỡng Innisfree Canola Honey Lip Balm",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 110000,
                    quantity = 100,
                    shop_id = "2",
                    image="DuongMoi1.jpg"
                },
                new Product{
                    id = "22",
                    product_name = "Son Dưỡng Môi Có Màu Innisfree Glow Tint Lip Balm",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 810000,
                    quantity = 100,
                    shop_id = "3",
                    image="DuongMoi2.jpg"
                },   
                new Product{
                    id = "23",
                    product_name = "Son Dưỡng 16Brand Fruit Chu Petit Lip Balm",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 170000,
                    quantity = 100,
                    shop_id = "1",
                    image="DuongMoi3.jpg"
                },
                new Product{
                    id = "24",
                    product_name = "Mặt Nạ Ngủ Môi Carenel Berry Lip Night Mask",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 920000,
                    quantity = 100,
                    shop_id = "2",
                    image="DuongMoi4.jpg"
                },
                new Product{
                    id = "25",
                    product_name = "Mặt Nạ Ngủ Môi Chiết Xuất Rau Má A'pieu Madecassoside Lip Sleeping Mask 20g",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "8",
                    price = 280000,
                    quantity = 100,
                    shop_id = "1",
                    image="DuongMoi5.jpg"
                },
                new Product{
                    id = "26",
                    product_name = "Kem nền Innisfree",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "9",
                    price = 670000,
                    quantity = 100,
                    shop_id = "2",
                    image="KemNen1.jpg"
                },
                new Product{
                    id = "27",
                    product_name = "Kem nền Power Perfection BB cream",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "9",
                    price = 100000,
                    quantity = 100,
                    shop_id = "3",
                    image="KemNen2.jpg"
                },
                new Product{
                    id = "28",
                    product_name = "Kem Nền Siêu Lì, Lâu Trôi A'pieu BB Maker Long Wear SPF30 PA+++",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "9",
                    price = 800000,
                    quantity = 100,
                    shop_id = "1",
                    image="KemNen3.jpg"
                },
                new Product{
                    id = "29",
                    product_name = "Kem Nền Che Phủ Hoàn Hảo, Giúp Da Bóng Khỏe, Rạng Rỡ Suốt 24 Tiếng Etude House Double Lasting Serum Foundation SPF25 PA++",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "9",
                    price = 700000,
                    quantity = 100,
                    shop_id = "2",
                    image="KemNen4.jpg"
                },
                new Product{
                    id = "30",
                    product_name = "Kem Nền Che Phủ Tốt, Lâu Trôi I'm Meme I'm Genius Foundation All Cover",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "9",
                    price = 300000,
                    quantity = 100,
                    shop_id = "3",
                    image="KemNen5.jpg"
                },
                new Product{
                    id = "31",
                    product_name = "Mascara Làm Dày Mi Không Lem Missha 4D Mascara",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 200000,
                    quantity = 100,
                    shop_id = "3",
                    image="Mascara1.jpg"
                },
                new Product{
                    id = "32",
                    product_name = "Mascara Siêu Dày Mi Innisfree Super Volumecara ",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 100000,
                    quantity = 100,
                    shop_id = "2",
                    image="Mascara.jpg"
                },
                new Product{
                    id = "33",
                    product_name = "Mascara Chân Mày Missha Color Wear Browcara",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 150000,
                    quantity = 100,
                    shop_id = "1",
                    image="Mascara2.jpg"
                },
                new Product{
                    id = "34",
                    product_name = "Mascara Chuốt Mi Cong Vút Tự Nhiên, Chống Trôi Etude House Lash Perm Curl Fix Mascara",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 350000,
                    quantity = 100,
                    shop_id = "1",
                    image="Mascara3.jpg"
                },
                new Product{
                    id = "35",
                    product_name = "Mascara Giúp Dài Mi Chống Trôi Missha Length Boost Cara",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 180000,
                    quantity = 100,
                    shop_id = "2",
                    image="Mascara4.jpg"
                },
                new Product{
                    id = "36",
                    product_name = "Mascara Chống Trôi , Làm Cong Mi Tự Nhiên Shionle Fixing High Heel Cara",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "10",
                    price = 210000,
                    quantity = 100,
                    shop_id = "3",
                    image="Mascara5.jpg"
                },
                new Product{
                    id = "37",
                    product_name = "Phấn phủ Play 101 Setting",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 230000,
                    quantity = 100,
                    shop_id = "1",
                    image="PhanPhu1.jpg"
                },
                new Product{
                    id = "38",
                    product_name = "Phấn phủ LANEIGE",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 340000,
                    quantity = 100,
                    shop_id = "2",
                    image="PhanPhu2.jpg"
                },
                new Product{
                    id = "39",
                    product_name = "Phấn Phủ Bột Kiềm Dầu Innisfree No Sebum Mineral Powder",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 290000,
                    quantity = 100,
                    shop_id = "3",
                    image="PhanPhu3.jpg"
                },
                new Product{
                    id = "40",
                    product_name = "Phấn Phủ Bột Kiềm Dầu, Cố Định Lớp Makeup A'pieu Mineral 100 HD Powder",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 320000,
                    quantity = 100,
                    shop_id = "1",
                    image="PhanPhu4.jpg"
                },
                new Product{
                    id = "41",
                    product_name = "Phấn Phủ Dạng Nén Kiềm Dầu, Che Phủ Lỗ Chân Lông A'pieu Oil Control Film Pact",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 450000,
                    quantity = 100,
                    shop_id = "2",
                    image="PhanPhu5.jpg"
                },
                new Product{
                    id = "42",
                    product_name = "Phấn Phủ Kiềm Dầu I'm Meme I'm Oil Cut Pact ",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "11",
                    price = 290000,
                    quantity = 100,
                    shop_id = "3",
                    image="PhanPhu6.jpg"
                },
                new Product{
                    id = "43",
                    product_name = "Son Thỏi Lì Merzy The First Lipstick",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 430000,
                    quantity = 100,
                    shop_id = "1",
                    image="SonLi.jpg"
                },
                new Product{
                    id = "44",
                    product_name = "Son Thỏi Lì ROM",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 850000,
                    quantity = 100,
                    shop_id = "2",
                    image="SonThoi.jpg"
                },
                new Product{
                    id = "45",
                    product_name = "Son Kem Lì Black Rouge Air Fit Velvet Tint",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 350000,
                    quantity = 100,
                    shop_id = "3",
                    image="Son1.jpg"
                },
                new Product{
                    id = "46",
                    product_name = "Son kem lì cực nhẹ môi Romand Zero Velvet Tint",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 210000,
                    quantity = 100,
                    shop_id = "1",
                    image="Son2.jpg"
                },
                new Product{
                    id = "47",
                    product_name = "Son Kem Lì Black Rouge Air Fit Velvet",
                    description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 370000,
                    quantity = 100,
                    shop_id = "2",
                    image="Son3.jpg"
                },
                new Product{
                    id = "48",
                    product_name = "Son Tint Lì Lâu Trôi Black Rouge Power Proof Matte Tint ",
                     description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "12",
                    price = 800000,
                    quantity = 100,
                    shop_id = "3",
                    image="Son4.jpg"
                }
                ,
                 new Product{
                    id = "49",
                    product_name = "Tinh chất dưỡng ",
                     description = "Sản phẩm chất lượng cao đến từ Hàn Quốc",
                    cat_id = "7",
                    price = 800000,
                    quantity = 100,
                    shop_id = "3",
                    image="Tinhchat.jpg"
                } , new Product{
                    id = "50",
                    product_name = "Kem chống nắng Innisfree SPF50+ PA++++",
                    description = "Kem trang điểm chống nắng Innisfree SPF50+ PA++++ được rất nhiều chị em trên khắp thế giới yêu thích là bởi chất kem nhẹ bẫng, mềm mượt, tạo nên một lớp trang điểm hoàn hảo mà vẫn có chỉ số chống nắng cao ngất ngưởng, có thể bảo vệ làn da tuyệt đối dưới ánh nắng mặt trời ngày hè",
                    cat_id = "3",
                    price = 900000,
                    quantity = 100,
                    shop_id = "1",
                    image = "ChongNang1.jpg"
                }
            );
        }
    }
}
