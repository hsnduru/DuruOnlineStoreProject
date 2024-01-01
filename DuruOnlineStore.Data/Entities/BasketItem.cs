using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class BasketItem : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int Quantity { get; set; } = 0;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
