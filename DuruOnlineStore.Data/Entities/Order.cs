using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Order
	{
		public int Id { get; set; }

		// Sipariş Veren Kullanıcı Bilgileri
		[Display(Name = "Kullanıcı Kimliği")]
		public int UserId { get; set; }

		[Required(ErrorMessage = "Adı alanı gereklidir.")]
		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Adı")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soyadı alanı gereklidir.")]
		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Soyadı")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "E-posta alanı gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
		[Column(TypeName = "varchar(80)"), StringLength(80), Display(Name = "EPosta Adresi")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Telefon alanı gereklidir.")]
		[Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Telefon")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Adres alanı gereklidir.")]
		[Column(TypeName = "varchar(100)"), StringLength(100), Display(Name = "Teslimat Adresi")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Ülke alanı gereklidir.")]
		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Teslimat Ülkesi")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Şehir alanı gereklidir.")]
		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Teslimat Şehri")]
		public string City { get; set; }

		[Required(ErrorMessage = "İlçe alanı gereklidir.")]
		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Teslimat İlçesi")]
		public string District { get; set; }

		[Column(TypeName = "varchar(10)"), StringLength(10), Display(Name = "Posta Kodu")]
		public string ZipCode { get; set; }

		[Display(Name = "Sipariş Notları")]
		public string? OrderNotes { get; set; }

		// Sipariş Detayları
		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Sipariş Numarası")]
		public string OrderNumber { get; set; }

		public ICollection<OrderDetail> OrderDetails { get; set; }

		[Display(Name = "Sipariş Durumu")]
		public EOrderStatus OrderStatus { get; set; }

		[Display(Name = "Ödeme Türü")]
		public EPaymentMethod PaymentMethod { get; set; }

		[Display(Name = "Sipariş Tarihi")]
		public DateTime OrderDate { get; set; }

		// Fiyat Bilgileri
		[Column(TypeName = "decimal(18,2)"), Display(Name = "Sepet Toplamı")]
		public decimal SubTotalPrice { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Kargo Ücreti")]
		public decimal ShippingPrice { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Genel Toplam")]
		public decimal TotalAmount { get; set; }
	}

    public enum EPaymentMethod
    {
		CashOnDelivery,	//Kapıda Ödeme
		CreditCard,     // Kredi Kartı 
		BankTransfer,   // Havale/EFT
		Paypal			// Paypal
	}

	public enum EOrderStatus
	{
		Pending,     // Beklemede
		Processing,  // Hazırlanıyor
		Shipped,     // Kargoya verildi
		Delivered,   // Teslim edildi
		Cancelled    // İptal edildi
	}
}
