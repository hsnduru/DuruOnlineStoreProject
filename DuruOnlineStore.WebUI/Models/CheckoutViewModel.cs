using DuruOnlineStore.Data.Entities;

namespace DuruOnlineStore.WebUI.Models
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public CartViewModel Cart { get; set; }
        public int UserId { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
