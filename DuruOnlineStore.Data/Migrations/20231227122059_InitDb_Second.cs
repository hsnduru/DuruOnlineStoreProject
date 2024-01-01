using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DuruOnlineStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDb_Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 10, "10", "Admin", "ADMIN" },
                    { 20, "20", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Makyaj" },
                    { 2, "", "Cilt Bakımı" },
                    { 3, "", "Saç Bakımı" },
                    { 4, "", "Kişisel Bakım" },
                    { 5, "", "Sağlık ve Hijyen" },
                    { 6, "", "Parfüm ve Deodorant" },
                    { 7, "", "Anne ve Bebek" },
                    { 8, "", "Erkek Bakımı" },
                    { 9, "", "Ev ve Yaşam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CampaignId", "CategoryId", "Description", "ImageName", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, null, 1, null, "loreal-paris-telescopic-mascara.jpg", "Loreal Paris Telescopic Maskara - Siyah", 260.00m, null },
                    { 2, null, 1, null, "flormar-fondoten-perfect-coverage.jpg", "Flormar Fondöten - Perfect Coverage Foundation No: 101 Pastelle", 229.90m, null },
                    { 3, null, 1, null, "maybelline-new-york-ruj-color-sensatio.jpg", "Maybelline New York Ruj - Color Sensational Creamy Matte Nudes 987 Smoky Rose", 215.00m, null },
                    { 4, null, 1, null, "loreal-paris-light-from-paradise.jpg", "Loreal Paris Light From Paradise Icoconic Glow Aydınlatıcı Pudra - 01 Coconut Addict", 150.00m, null },
                    { 5, null, 1, null, "neutrogena-goz-makyaj-temizleyicisi.jpg", "Neutrogena Deep Clean Göz Makyaj Temizleyicisi 125 ml", 134.90m, null },
                    { 6, null, 2, null, "neutrogena-ultra-nourishing.jpg", "Neutrogena Ultra Nourishing Besleyici Bakım Kremi 300 ml", 142.90m, null },
                    { 7, null, 2, null, "nivea-nemlendirici-yuz-maskesi-hydra.jpg", "Nivea Nemlendirici Yüz Maskesi - Hydra Skin Effect", 200.00m, null },
                    { 8, null, 2, null, "arkoarko-nem-krem-250-ml-ekstra-nemel.jpg", "Arko Nem Krem Ekstra Nem Temel Bakım Serisi 250 ml", 64.90m, null },
                    { 9, null, 2, null, "nivea-sun-koruma-ve-nem-spf-50-faktor.jpg", "Nivea Sun Sprey Güneş Kremi Koruma Ve Nem +Spf50 200 ml", 447.90m, null },
                    { 10, null, 2, null, "neutrogena-siyah-nokta-karsiti-gunluk.jpg", "Neutrogena Siyah Nokta Karşıtı Günlük Peeling Jel 150 ml", 99.90m, null },
                    { 11, null, 3, null, "koleston-kit-sac-boyasi-30-koyu-kahve.jpg", "Koleston Kit Saç Boyası 3/0 Koyu Kahve", 166.00m, null },
                    { 12, null, 3, null, "palette-kit-sac-boyasi-10.1-kullu-sari.jpg", "Palette Delux Kit Saç Boyası 10.1 Küllü Açık Sarı", 79.00m, null },
                    { 13, null, 3, null, "bioblas-forte-bitkisel-serum-sac-dokul.jpg", "Bioblas Forte Bitkisel Serum - Saç Dökülmesine Karşı Etkili 100 ml", 79.90m, null },
                    { 14, null, 3, null, "dove-sampuan-uzun-saclar-600-mlsampuan.jpg", "Dove Şampuan Uzun Saç Terapisi 600 ml", 89.90m, null },
                    { 15, null, 3, null, "gliss-sivi-sac-bakim-kremi-ultimate-oil.jpg", "Gliss Sıvı Saç Bakım Kremi Ultimate Oil Elixir 200 ml", 114.00m, null },
                    { 16, null, 4, null, "duru-dus-jeli-450-ml-moods-deniz-miner.jpg", "Duru Moods Duş Jeli Deniz Minerali & Aloe Vera Özlü 450 ml", 55.00m, null },
                    { 17, null, 4, null, "sensodyn-ferah-nefes-dis-macunu-75-ml.jpg", "Sensodyn Ferah Nefes Diş Macunu 75 ml", 75.00m, null },
                    { 18, null, 4, null, "colgate-plax-nane-agiz-bakim-suyu-500.jpg", "Colgate Plax Nane Ağız Bakım Suyu 500 ml", 104.90m, null },
                    { 19, null, 4, null, "misip-kurdanli-dis-ipi-50-adet.jpg", "Misip Kürdanlı Diş İpi Silindir Kutu 50li", 39.90m, null },
                    { 20, null, 4, null, "lionesse-2li-tirnak-makasi-seti-5106.jpg", "Lionesse 2li Tırnak Makası Seti 5106", 75.00m, null },
                    { 21, null, 5, null, "kotex-active-hijyenik-ped-ultra-extra.jpg", "Kotex Active Hijyenik Ped Ultra Extra Normal 8li", 49.00m, null },
                    { 22, null, 5, null, "orkid-gunluk-ped-gunluk-koruma-dev-eko.jpg", "Orkid Günlük Ped Günlük Koruma Dev Ekonomi Paketi 48li", 125.00m, null },
                    { 23, null, 5, null, "durex-prezervatif-yok-otesi-ekstra-ser.jpg", "Durex Prezervatif Yok Ötesi Ekstra İnce 10lu", 189.90m, null },
                    { 24, null, 5, null, "duru-sprey-limon-kolonyasi-150-ml.jpg", "Duru Sprey Limon Kolonyası 150 ml", 35.00m, null },
                    { 25, null, 5, null, "le-petit-marseillais-sivi-sabun-lavanta.jpg", "Le Petit Marseillais Sıvı Sabun Lavanta Özlü 300 ml", 84.90m, null },
                    { 26, null, 6, null, "ninovaparfum-ve-deodorantlar.jpg", "Ninova Women VIII Parfüm Edp 100 ml", 379.50m, null },
                    { 27, null, 6, null, "emotion-romance-kadin-parfumu-edt-50-m.jpg", "Emotion Romance Kadın Parfümü Edt 50 ml", 249.00m, null },
                    { 28, null, 6, null, "nivea-kadin-deodorant-pearl-beauty-150.jpg", "Nivea Kadın Deodorant - Pearl & Beauty 150 ml", 115.00m, null },
                    { 29, null, 6, null, "axe-erkek-deodorant-dark-temptation.jpg", "Axe Erkek Deodorant Dark Temptation 150 ml", 113.50m, null },
                    { 30, null, 6, null, "bon-veno-100-ml-150-ml-deo-for-men-giff.jpg", "Bon Veno For Men Giff Oud Kofre/Parfüm Seti 100 ml + Deodorant 150 ml", 229.90m, null },
                    { 31, null, 7, null, "dalin-bebek-bakim-yagi-500-ml.jpg", "Dalin Bebek Bakım Yağı 500 ml", 139.50m, null },
                    { 32, null, 7, null, "johnsons-baby-bebek-sampuani-pompali.jpg", "Johnsons Baby Bebek Şampuanı Pompalı 750 ml", 89.00m, null },
                    { 33, null, 7, null, "dalin-islak-mendil-64lubebek.jpg", "Dalin Islak Mendil 64lü", 39.90m, null },
                    { 34, null, 7, null, "johnsons-baby-bedtime-vucut-yagi-300.jpg", "Johnsons Baby Bedtime Vücut Yağı 300 ml", 89.00m, null },
                    { 35, null, 7, null, "sebamed-baby-bebek-kremi-extra-yumusak.jpg", "Sebamed Baby Bebek Kremi Extra Yumuşak 200 ml", 289.90m, null },
                    { 36, null, 8, null, "arko-tiras-kopugu-cool-200-ml.jpg", "Arko Tıraş Köpüğü Cool 200 ml", 80.00m, null },
                    { 37, null, 8, null, "veet-men-dusta-tuy-dokucu-krem-150-ml.jpg", "Veet Men Duşta Tüy Dökücü Krem 150 ml", 199.90m, null },
                    { 38, null, 8, null, "gillette-blue-3-tffkullan-at-tiras-bic.jpg", "Gillette Blue 3 Kullan At Tıraş Bıçağı 6lı", 194.00m, null },
                    { 39, null, 8, null, "nivea-sport-erkekler-icin-sac-yuz-vuc.jpg", "Nivea Sport Erkekler İçin Saç & Yüz & Vücut Jeli 500 ml", 124.90m, null },
                    { 40, null, 8, null, "nivea-men-tiras-losyonu-deep-dimension.jpg", "Nivea Men Tıraş Losyonu - Deep Dimension Comfort 100 ml", 195.00m, null },
                    { 41, null, 9, null, "kokulu-tealight-mum-18li.jpg", "Kokulu Tealight Mum", 119.90m, null },
                    { 42, null, 9, null, "lionessse-seyahat-seti.jpg", "Lionessse Seyahat Seti 7912", 168.00m, null },
                    { 43, null, 9, null, "bardak-mum-tekli-kutulu.jpg", "Bardak Mum Tekli Kutulu", 100.00m, null },
                    { 44, null, 9, null, "silindir-mum-40x60-parlak-kirmizi-4lu.jpg", "Silindir Mum 40X60 Parlak Kırmızı", 99.90m, null },
                    { 45, null, 9, null, "tealight-mum-yesil-50li.jpg", "Tealight Mum Yeşil", 139.90m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CustomerId",
                table: "BasketItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CampaignId",
                table: "Products",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
