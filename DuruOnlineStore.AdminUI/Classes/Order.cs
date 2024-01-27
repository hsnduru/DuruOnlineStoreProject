using DuruOnlineStore.Data.Base;
using DuruOnlineStore.Data.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Order : EntityBase
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
