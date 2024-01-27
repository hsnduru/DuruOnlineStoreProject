using DuruOnlineStore.Data.Base;
using DuruOnlineStore.Data.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class CartItem : EntityBase
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int Quantity { get; set; } = 1;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
