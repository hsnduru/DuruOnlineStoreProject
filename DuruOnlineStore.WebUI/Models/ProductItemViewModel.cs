using DuruOnlineStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.WebUI.Models
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Kategori")]
        public string Category { get; set; }

        [Display(Name = "Kampanya")]
        public string Campaign { get; set; }

        [Display(Name = "Stok")]
        public int StockQuantity { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? Star { get; set; }

        [Display(Name = "Yeni Ürün")]
        public bool IsNew { get; set; }

        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name = "İndirim Oranı")]
        public int? DiscountRate { get; set; }

        [Display(Name = "İndirim Tutarı")]
        public decimal DiscountAmount
        {
            get
            {
                if (!DiscountRate.HasValue || !Price.HasValue)
                    return 0;

                return Price.Value * (DiscountRate.Value / 100m);
            }
        }

        public decimal? FinalPrice => (DiscountAmount == 0) ? Price : Price - DiscountAmount;

        [Display(Name = "Eklenme Tarihi")]
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public bool IsRecentlyAdded()
        {
            TimeSpan difference = DateTime.Now - AddedDate;
            return difference.TotalDays <= 15;
        }
    }
}
