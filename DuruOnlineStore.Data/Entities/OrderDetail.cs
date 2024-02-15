using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class OrderDetail
	{
        public int Id { get; set; }

        [Display(Name = "Sipariş")]
		public int OrderId { get; set; }
        public Order Order { get; set; }

		[Display(Name = "Ürün ID")]
		public int ProductId { get; set; }

		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ürün Adı")]
		public string ProductName { get; set; }

        [Display(Name = "Ürün Resmi")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Miktar")]
		public int Quantity { get; set; }

        [Display(Name = "Toplam")]
		public decimal? FinalPrice { get; set; }
	}
}
