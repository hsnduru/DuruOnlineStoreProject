using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Campaign : EntityBase, INameEntity
    {
        public string Name { get; set; } = "";

        [Display(Name = "Açıklama")]
        public string Description { get; set; } = "";

        public bool IsActive { get; set; } = true;
        public int? DiscountRate { get; set; }

        public virtual List<Product>? Pruducts { get; set; }
    }
}
