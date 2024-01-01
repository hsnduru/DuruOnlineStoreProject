using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; } // Ödeme yöntemi adı (Örn. Kredi Kartı, PayPal)
        public string Description { get; set; } // Ödeme yöntemi hakkında açıklama
    }
}
