using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Product : EntityBase, INameEntity
    {
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; } = "";

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
       
        [Display(Name = "Stok Miktarı")]
        public int? StockQuantity { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [Display(Name = "Kampanya")]
        [ScaffoldColumn(false)]
        public int? CampaignId { get; set; }
        [ScaffoldColumn(false)]
        public virtual Campaign? Campaign { get; set; }

        [ScaffoldColumn(false)]
        public string? ImageName{ get; set; }
        
    }
}
