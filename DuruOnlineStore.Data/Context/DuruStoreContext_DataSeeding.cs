using DuruOnlineStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Context;

public partial class DuruStoreContext
{
    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
                        new Category { Id = 1, Name = "Makyaj" },
                        new Category { Id = 2, Name = "Cilt Bakımı" },
                        new Category { Id = 3, Name = "Saç Bakımı" },
                        new Category { Id = 4, Name = "Kişisel Bakım" },
                        new Category { Id = 5, Name = "Sağlık ve Hijyen" },
                        new Category { Id = 6, Name = "Parfüm ve Deodorant" },
                        new Category { Id = 7, Name = "Anne ve Bebek" },
                        new Category { Id = 8, Name = "Erkek Bakımı" },
                        new Category { Id = 9, Name = "Ev ve Yaşam" });
    }

    private static void SeedProducts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
                        new Product { Id = 1, Name = "Loreal Paris Telescopic Maskara - Siyah", CategoryId = 1, Price = 260.00m, ImageName = "loreal-paris-telescopic-mascara.jpg" },
                        new Product { Id = 2, Name = "Flormar Fondöten - Perfect Coverage Foundation No: 101 Pastelle", CategoryId = 1, Price = 229.90m, ImageName = "flormar-fondoten-perfect-coverage.jpg" },
                        new Product { Id = 3, Name = "Maybelline New York Ruj - Color Sensational Creamy Matte Nudes 987 Smoky Rose", CategoryId = 1, Price = 215.00m, ImageName = "maybelline-new-york-ruj-color-sensatio.jpg" },
                        new Product { Id = 4, Name = "Loreal Paris Light From Paradise Icoconic Glow Aydınlatıcı Pudra - 01 Coconut Addict", CategoryId = 1, Price = 150.00m, ImageName = "loreal-paris-light-from-paradise.jpg" },
                        new Product { Id = 5, Name = "Neutrogena Deep Clean Göz Makyaj Temizleyicisi 125 ml", CategoryId = 1, Price = 134.90m, ImageName = "neutrogena-goz-makyaj-temizleyicisi.jpg" },
                        
                        new Product { Id = 6, Name = "Neutrogena Ultra Nourishing Besleyici Bakım Kremi 300 ml", CategoryId = 2, Price = 142.90m, ImageName = "neutrogena-ultra-nourishing.jpg" },
                        new Product { Id = 7, Name = "Nivea Nemlendirici Yüz Maskesi - Hydra Skin Effect", CategoryId = 2, Price = 200.00m, ImageName = "nivea-nemlendirici-yuz-maskesi-hydra.jpg" },
                        new Product { Id = 8, Name = "Arko Nem Krem Ekstra Nem Temel Bakım Serisi 250 ml", CategoryId = 2, Price = 64.90m, ImageName = "arkoarko-nem-krem-250-ml-ekstra-nemel.jpg" },
                        new Product { Id = 9, Name = "Nivea Sun Sprey Güneş Kremi Koruma Ve Nem +Spf50 200 ml", CategoryId = 2, Price = 447.90m, ImageName = "nivea-sun-koruma-ve-nem-spf-50-faktor.jpg" },
                        new Product { Id = 10, Name = "Neutrogena Siyah Nokta Karşıtı Günlük Peeling Jel 150 ml", CategoryId = 2, Price = 99.90m, ImageName = "neutrogena-siyah-nokta-karsiti-gunluk.jpg" },
                        
                        new Product { Id = 11, Name = "Koleston Kit Saç Boyası 3/0 Koyu Kahve", CategoryId = 3, Price = 166.00m, ImageName = "koleston-kit-sac-boyasi-30-koyu-kahve.jpg" },
                        new Product { Id = 12, Name = "Palette Delux Kit Saç Boyası 10.1 Küllü Açık Sarı", CategoryId = 3, Price = 79.00m, ImageName = "palette-kit-sac-boyasi-10.1-kullu-sari.jpg" },
                        new Product { Id = 13, Name = "Bioblas Forte Bitkisel Serum - Saç Dökülmesine Karşı Etkili 100 ml", CategoryId = 3, Price = 79.90m, ImageName = "bioblas-forte-bitkisel-serum-sac-dokul.jpg" },
                        new Product { Id = 14, Name = "Dove Şampuan Uzun Saç Terapisi 600 ml", CategoryId = 3, Price = 89.90m, ImageName = "dove-sampuan-uzun-saclar-600-mlsampuan.jpg" },
                        new Product { Id = 15, Name = "Gliss Sıvı Saç Bakım Kremi Ultimate Oil Elixir 200 ml", CategoryId = 3, Price = 114.00m, ImageName = "gliss-sivi-sac-bakim-kremi-ultimate-oil.jpg" },
                        
                        new Product { Id = 16, Name = "Duru Moods Duş Jeli Deniz Minerali & Aloe Vera Özlü 450 ml", CategoryId = 4, Price = 55.00m, ImageName = "duru-dus-jeli-450-ml-moods-deniz-miner.jpg" },
                        new Product { Id = 17, Name = "Sensodyn Ferah Nefes Diş Macunu 75 ml", CategoryId = 4, Price = 75.00m, ImageName = "sensodyn-ferah-nefes-dis-macunu-75-ml.jpg" },
                        new Product { Id = 18, Name = "Colgate Plax Nane Ağız Bakım Suyu 500 ml", CategoryId = 4, Price = 104.90m, ImageName = "colgate-plax-nane-agiz-bakim-suyu-500.jpg" },
                        new Product { Id = 19, Name = "Misip Kürdanlı Diş İpi Silindir Kutu 50li", CategoryId = 4, Price = 39.90m, ImageName = "misip-kurdanli-dis-ipi-50-adet.jpg" },
                        new Product { Id = 20, Name = "Lionesse 2li Tırnak Makası Seti 5106", CategoryId = 4, Price = 75.00m, ImageName = "lionesse-2li-tirnak-makasi-seti-5106.jpg" },
                        
                        new Product { Id = 21, Name = "Kotex Active Hijyenik Ped Ultra Extra Normal 8li", CategoryId = 5, Price = 49.00m, ImageName = "kotex-active-hijyenik-ped-ultra-extra.jpg" },
                        new Product { Id = 22, Name = "Orkid Günlük Ped Günlük Koruma Dev Ekonomi Paketi 48li", CategoryId = 5, Price = 125.00m, ImageName = "orkid-gunluk-ped-gunluk-koruma-dev-eko.jpg" },
                        new Product { Id = 23, Name = "Durex Prezervatif Yok Ötesi Ekstra İnce 10lu", CategoryId = 5, Price = 189.90m, ImageName = "durex-prezervatif-yok-otesi-ekstra-ser.jpg" },
                        new Product { Id = 24, Name = "Duru Sprey Limon Kolonyası 150 ml", CategoryId = 5, Price = 35.00m, ImageName = "duru-sprey-limon-kolonyasi-150-ml.jpg" },
                        new Product { Id = 25, Name = "Le Petit Marseillais Sıvı Sabun Lavanta Özlü 300 ml", CategoryId = 5, Price = 84.90m, ImageName = "le-petit-marseillais-sivi-sabun-lavanta.jpg" },
                        
                        new Product { Id = 26, Name = "Ninova Women VIII Parfüm Edp 100 ml", CategoryId = 6, Price = 379.50m, ImageName = "ninovaparfum-ve-deodorantlar.jpg" },
                        new Product { Id = 27, Name = "Emotion Romance Kadın Parfümü Edt 50 ml", CategoryId = 6, Price = 249.00m, ImageName = "emotion-romance-kadin-parfumu-edt-50-m.jpg" },
                        new Product { Id = 28, Name = "Nivea Kadın Deodorant - Pearl & Beauty 150 ml", CategoryId = 6, Price = 115.00m, ImageName = "nivea-kadin-deodorant-pearl-beauty-150.jpg" },
                        new Product { Id = 29, Name = "Axe Erkek Deodorant Dark Temptation 150 ml", CategoryId = 6, Price = 113.50m, ImageName = "axe-erkek-deodorant-dark-temptation.jpg" },
                        new Product { Id = 30, Name = "Bon Veno For Men Giff Oud Kofre/Parfüm Seti 100 ml + Deodorant 150 ml", CategoryId = 6, Price = 229.90m, ImageName = "bon-veno-100-ml-150-ml-deo-for-men-giff.jpg" },
                        
                        new Product { Id = 31, Name = "Dalin Bebek Bakım Yağı 500 ml", CategoryId = 7, Price = 139.50m, ImageName = "dalin-bebek-bakim-yagi-500-ml.jpg" },
                        new Product { Id = 32, Name = "Johnsons Baby Bebek Şampuanı Pompalı 750 ml", CategoryId = 7, Price = 89.00m, ImageName = "johnsons-baby-bebek-sampuani-pompali.jpg" },
                        new Product { Id = 33, Name = "Dalin Islak Mendil 64lü", CategoryId = 7, Price = 39.90m, ImageName = "dalin-islak-mendil-64lubebek.jpg" },
                        new Product { Id = 34, Name = "Johnsons Baby Bedtime Vücut Yağı 300 ml", CategoryId = 7, Price = 89.00m, ImageName = "johnsons-baby-bedtime-vucut-yagi-300.jpg" },
                        new Product { Id = 35, Name = "Sebamed Baby Bebek Kremi Extra Yumuşak 200 ml", CategoryId = 7, Price = 289.90m, ImageName = "sebamed-baby-bebek-kremi-extra-yumusak.jpg" },
                        
                        new Product { Id = 36, Name = "Arko Tıraş Köpüğü Cool 200 ml", CategoryId = 8, Price = 80.00m, ImageName = "arko-tiras-kopugu-cool-200-ml.jpg" },
                        new Product { Id = 37, Name = "Veet Men Duşta Tüy Dökücü Krem 150 ml", CategoryId = 8, Price = 199.90m, ImageName = "veet-men-dusta-tuy-dokucu-krem-150-ml.jpg" },
                        new Product { Id = 38, Name = "Gillette Blue 3 Kullan At Tıraş Bıçağı 6lı", CategoryId = 8, Price = 194.00m, ImageName = "gillette-blue-3-tffkullan-at-tiras-bic.jpg" },
                        new Product { Id = 39, Name = "Nivea Sport Erkekler İçin Saç & Yüz & Vücut Jeli 500 ml", CategoryId = 8, Price = 124.90m, ImageName = "nivea-sport-erkekler-icin-sac-yuz-vuc.jpg" },
                        new Product { Id = 40, Name = "Nivea Men Tıraş Losyonu - Deep Dimension Comfort 100 ml", CategoryId = 8, Price = 195.00m, ImageName = "nivea-men-tiras-losyonu-deep-dimension.jpg" },
                        
                        new Product { Id = 41, Name = "Kokulu Tealight Mum", CategoryId = 9, Price = 119.90m, ImageName = "kokulu-tealight-mum-18li.jpg" },
                        new Product { Id = 42, Name = "Lionessse Seyahat Seti 7912", CategoryId = 9, Price = 168.00m, ImageName = "lionessse-seyahat-seti.jpg" },
                        new Product { Id = 43, Name = "Bardak Mum Tekli Kutulu", CategoryId = 9, Price = 100.00m, ImageName = "bardak-mum-tekli-kutulu.jpg" },
                        new Product { Id = 44, Name = "Silindir Mum 40X60 Parlak Kırmızı", CategoryId = 9, Price = 99.90m, ImageName = "silindir-mum-40x60-parlak-kirmizi-4lu.jpg" },
                        new Product { Id = 45, Name = "Tealight Mum Yeşil", CategoryId = 9, Price = 139.90m, ImageName = "tealight-mum-yesil-50li.jpg" });
                     
    }
}

