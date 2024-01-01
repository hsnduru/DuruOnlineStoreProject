using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class ProductImage : EntityBase
    {
        public string FileName { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
