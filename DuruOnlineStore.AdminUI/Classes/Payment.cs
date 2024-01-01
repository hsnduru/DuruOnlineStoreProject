using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; } // Hangi siparişe ait olduğunu belirtmek için
        public decimal Amount { get; set; } // Ödeme tutarı
        public DateTime PaymentDate { get; set; } // Ödeme tarihi
        public string PaymentMethod { get; set; } // Kredi kartı, PayPal, vb.
        public string TransactionId { get; set; } // Ödeme işlemi için benzersiz bir kimlik
    }
}
