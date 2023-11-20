using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Trần Phách Hàm", "Đời người giống như trò chơi, mỗi bước đều phải cân nhắc xem đi như thế nào, đi về đâu, phải kết hợp nhiều yếu tố lại chúng ta mới có thể đưa ra được lựa chọn. Mà trong quá trình chọn lựa này các yếu tố khiến ta phải cân nhắc và những đường đi khác nhau sẽ ảnh hưởng trực tiếp đến kết quả.", "8936066697088", 30.0, 27.0, 20.0, 25.0, "Lý Thuyết Trò Chơi" },
                    { 2, "Song Hong Bing", "Một khi đọc “Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” bạn sẽ phải giật mình nhận ra một điều kinh khủng rằng, đằng sau những tờ giấy bạc chúng ta chi tiêu hàng ngày là cả một thế lực ngầm đáng sợ - một thế lực bí ẩn với quyền lực siêu nhiên có thể điều khiển cả thế giới rộng lớn này.\r\n\r\n“Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” đề cập đến một cuộc chiến khốc liệt, không khoan nhượng và dai dẳng giữa một nhóm nhỏ các ông trùm tài chính – đứng đầu là gia tộc Rothschild – với các thể chế tài chính của nhiều quốc gia. Đó là một cuộc chiến mà đồng tiền là súng đạn và mức sát thương thật sự ghê gớm.\r\n\r\nĐồng thời, “Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” còn giúp bạn hiểu thêm nhiều điều, rằng Bill Gates chưa phải là người giàu nhất hành tinh, rằng tỉ lệ tử vong của các tổng thống Mỹ lại cao hơn tỉ lệ tử trận của binh lính Mỹ ngoài chiến trường, hay vì sao phố Wall lại mạo hiểm đổ hết vốn liếng của mình cho việc “đầu tư” vào Hitler.\r\n\r\nLà một cuốn sách làm sửng sốt những ai muốn tìm hiểu về bản chất của tiền tệ, để từ đó nhận ra những hiểm họa tài chính tiềm ẩn nhằm chuẩn bị tâm lý cho một cuộc chiến tiền tệ “không đổ máu”, “Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” còn phơi bày những âm mưu của các nhà tài phiệt thế giới trong việc tạo ra những cơn “hạn hán”, “bão lũ” về tiền tệ để thu lợi nhuận. Cuốn sách cũng đề cập đến sự phát triển của các định chế tài chính – những cơ cấu được xây dựng nhằm đáp ứng nhu cầu phát triển vũ bão của nền kinh tế toàn cầu.\r\n\r\nGấp cuốn sách lại, có thể bạn đọc sẽ có nhiều tâm trạng khác nhau. Đối với một số người, đó có thể là sự sợ hãi thế lực tài chính quốc tế và cảm giác bất an về sự chi phối của thế lực này. Với số khác thì đó có thể là một cảm giác thú vị khi khám phá ra sự thật trần trụi để từ đó có cách nhìn nhận khác nhằm xây dựng cho mình những kế hoạch đầu tư một cách hiệu quả nhất. Và cho dù bạn có lo sợ hay cảm thấy tò mò, thú vị thì “Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” cũng là một cuốn sách đáng đọc. Một cuốn sách bổ ích cho các chuyên gia quản lý tài chính, các nhà quản trị doanh nghiệp, các nhà đầu tư nhỏ, các giáo viên giảng dạy về tài chính – ngân hàng cũng như sinh viên các trường kinh tế.\r\n\r\nMã hàng	9786043437881\r\nTên Nhà Cung Cấp	Bách Việt\r\nTác giả	Song Hong Bing\r\nNgười Dịch	Hồ Ngọc Minh\r\nNXB	NXB Lao Động\r\nNăm XB	2022\r\nTrọng lượng (gr)	570\r\nKích Thước Bao Bì	24 x 16 x 1.5 cm\r\nSố trang	532\r\nHình thức	Bìa Mềm\r\nSản phẩm hiển thị trong	\r\nBách Việt\r\nFlashsale\r\nMã Giảm Giá\r\nRƯỚC DEAL LINH ĐÌNH VUI ĐÓN TRUNG THU\r\nSản phẩm bán chạy nhất	Top 100 sản phẩm Phân Tích Kinh Tế bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nChính sách khuyến mãi trên Fahasa.com không áp dụng cho Hệ thống Nhà sách Fahasa trên toàn quốc\r\nChiến Tranh Tiền Tệ - Phần 1 - Ai Thực Sự Là Người Giàu Nhất Thế Giới?\r\n\r\nMột khi đọc “Chiến tranh tiền tệ - Ai thật sự là người giàu nhất thế giới” bạn sẽ phải giật mình nhận ra một điều kinh khủng rằng, đằng sau những tờ giấy bạc chúng ta chi tiêu hàng ngày là cả một thế lực ngầm đáng sợ - một thế lực bí ẩn với quyền lực siêu nhiên có thể điều khiển cả thế giới rộng lớn này.", "9786043437881", 30.0, 27.0, 20.0, 25.0, "Chiến Tranh Tiền Tệ - Phần 1" },
                    { 3, "Bessel Van Der Kolk, M.D", "Hiện nay, chúng ta đã biết rằng sang chấn gây ra những thay đổi về sinh lý học trong cơ thể, những thứ giúp ta cảm nhận được mình đang sống. Những thay đổi này giải thích tại sao các cá nhân bị sang chấn trở nên nhạy cảm hơn đối với những hiểm họa ngay cả khi họ đang tham gia cuộc sống thường ngày.", "8935278601715", 30.0, 27.0, 20.0, 25.0, "Sang Chấn Tâm Lý - Hiểu Để Chữa Lành" },
                    { 4, "Jeffrey Archer", "Jeffrey Archer là nhà văn người Anh và cũng là một chính trị gia. Ông từng là một thành viên của Quốc hội và Phó Chủ tịch Đảng Bảo thủ.\r\n\r\n", "8935095633210", 30.0, 27.0, 20.0, 25.0, "Hai Số Phận (Tái Bản 2023)" },
                    { 5, "Avinash K. Dixit, Barry J. Nalebuff", "Tư duy chiến lược là nghệ thuật vượt qua đối thủ cạnh tranh, với nhận thức rằng họ cũng đang cố gắng vượt qua mình. Mỗi chúng ta đều phải áp dụng tư duy chiến lược, theo cách này hay cách khác, tại nơi làm việc và ngay cả ở nhà", "9786043857870", 30.0, 27.0, 20.0, 25.0, "Tư Duy Chiến Lược - Lý Thuyết Trò Chơi Thực Hành" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
