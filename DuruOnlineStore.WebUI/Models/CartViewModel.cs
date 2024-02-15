using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.WebUI.Models
{
	public class CartItemViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Ürün Adı")]
		public string? Name { get; set; }

		[Display(Name = "Ürün Resmi")]
		public string? ImageUrl { get; set; }

		public decimal? UnitPrice { get; set; }

		[Display(Name = "Fiyat")]
		public decimal? Price => UnitPrice - DiscountAmount;

		[Display(Name = "İndirim Oranı")]
		public int? DiscountRate { get; set; }

		public decimal DiscountAmount
		{
			get
			{
				if (!DiscountRate.HasValue)
					return 0;
				else
					return UnitPrice.Value * (DiscountRate.Value / 100m);
			}
		}
		public decimal? FinalPrice => Quantity * ((DiscountAmount == 0) ? UnitPrice : UnitPrice - DiscountAmount);

		[Display(Name = "Adet")]
		public int Quantity { get; set; }
	}

	public class CartViewModel
	{
		public List<CartItemViewModel> Items { get; set; }
		
		[Display(Name = "Sepet Toplamı")]
		public decimal SubTotalPrice => Items.Sum(x => x.FinalPrice ?? 0);

        [Display(Name = "Kargo Ücreti")]
        public decimal ShippingPrice
        {
            get
            {
                if (SubTotalPrice >= 750)
                {
                    return 0; 
                }
                else
                {
                    return 50;
                }
            }
        }

        public bool ShippingIsFree => SubTotalPrice >= 750;

        [Display(Name = "Genel Toplam")]
		public decimal TotalAmount => SubTotalPrice + ShippingPrice;

        public int ItemCount => Items.Sum(x => x.Quantity);
	}
}
