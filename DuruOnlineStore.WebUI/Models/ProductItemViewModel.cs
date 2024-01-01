using DuruOnlineStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.WebUI.Models
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        public string Category { get; set; }

        [Display(Name = "Kampanya")]
        public string Campaign { get; set; }

        [Display(Name = "Stok")]
        public int StockQuantity { get; set; }

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

    }
}
