using DuruOnlineStore.Data.Entities;
using System.ComponentModel.DataAnnotations;
using DuruOnlineStore.Common.Configurations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuruOnlineStore.AdminUI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        public string Category { get; set; }

        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Stok")]
        public int StockQuantity { get; set; }

        [Display(Name = "Kampanya")]
        public string Campaign { get; set; }

        public string ImageUrl { get; set; }
    }
}
