using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class PaymentStatus
    {
        public int PaymentStatusId { get; set; }
        public string Name { get; set; } // Ödeme durumu adı (Örn. Beklemede, Başarılı, Başarısız)
        public string Description { get; set; } // Ödeme durumu hakkında açıklama
    }
}
