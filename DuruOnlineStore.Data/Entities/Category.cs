using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Category : EntityBase, INameEntity 
    {
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } = "";

        [Display(Name = "Açıklama")]
        public string? Description { get; set; } = "";

        public virtual List<Product>? Products { get; set; }
    }
}
