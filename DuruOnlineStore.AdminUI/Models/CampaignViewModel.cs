using DuruOnlineStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.AdminUI.Models
{
    public class CampaignViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kampanya Adı")]
        public string Name { get; set; } = "";

        [Display(Name = "Açıklama")]
        public string Description { get; set; } = "";

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "İndirim Oranı")]
        public int? DiscountRate { get; set; }

        public virtual List<Product>? Products { get; set; }
    }
}
