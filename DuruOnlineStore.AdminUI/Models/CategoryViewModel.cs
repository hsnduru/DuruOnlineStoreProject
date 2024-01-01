using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.AdminUI.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } 

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ürün Sayısı")]
        public int ProductCount { get; set; }
    }
}
