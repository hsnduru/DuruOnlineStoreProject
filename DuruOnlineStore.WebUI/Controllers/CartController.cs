using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.Data.Entities.Identities;
using DuruOnlineStore.WebUI.Models;
using DuruOnlineStore.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DuruOnlineStore.WebUI.Controllers
{
	public class CartController : Controller
	{
		private ICartService _cartService;
		private SignInManager<AppUser> _SignInManager;
		private DuruStoreContext _dbContext;

		public CartController(ICartService cartService, SignInManager<AppUser> signInManager, DuruStoreContext dbContext)
		{
			_cartService = cartService;
			_SignInManager = signInManager;
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var cart = _cartService.GetCart();

			return View(cart);
		}

        //      public IActionResult Checkout()
        //      {
        //	var cart = _cartService.GetCart();
        //	ViewBag.CartItems = cart.Items;

        //	ViewBag.SubTotalPrice = cart.SubTotalPrice;
        //	ViewBag.ShippingPrice = cart.ShippingPrice;
        //	ViewBag.TotalAmount = cart.TotalAmount;

        //	return View();
        //}

        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCart();

            var checkoutViewModel = new CheckoutViewModel
            {
                Order = new Order(),
                Cart = new CartViewModel
                {
                    Items = cart.Items.Select(item => new CartItemViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ImageUrl = item.ImageUrl,
                        UnitPrice = item.UnitPrice,
                        DiscountRate = item.DiscountRate,
                        Quantity = item.Quantity
                    }).ToList()
                }
            };

            return View(checkoutViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = model.Order;
                order.OrderDate = DateTime.Now;

                //string orderNumber = DateTime.Now.Microsecond.ToString()
                //    + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
                //    + DateTime.Now.Hour.ToString() + DateTime.Now.Microsecond.ToString()
                //    + DateTime.Now.Microsecond.ToString();

                string orderNumber = Guid.NewGuid().ToString();
                if (orderNumber.Length > 20)
                {
                    orderNumber = orderNumber.Substring(0, 20);
                    order.OrderNumber = orderNumber;
                }

                order.OrderStatus = EOrderStatus.Pending;

                if (Enum.TryParse(typeof(EPaymentMethod), model.PaymentMethod, out var paymentMethod))
                {
                    order.PaymentMethod = (EPaymentMethod)paymentMethod;
                }
                else
                {
                    ModelState.AddModelError("PaymentMethod", "Geçersiz ödeme yöntemi.");
                    return View(model);
                }

                order.SubTotalPrice = model.Cart.SubTotalPrice;
                order.ShippingPrice = model.Cart.ShippingPrice;
                order.TotalAmount = model.Cart.TotalAmount;


                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                var cartItems = model.Cart.Items;
                foreach (var item in cartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = item.Id,
                        ProductName = item.Name,
                        ImageUrl = item.ImageUrl,
                        Quantity = item.Quantity,
                        FinalPrice = item.FinalPrice
                    };
                    _dbContext.OrderDetails.Add(orderDetail);
                }
                _dbContext.SaveChanges();

                _cartService.ClearCart();

                // Başarılı ödeme sonrası ana sayfaya yönlendir
                //return RedirectToAction("Index", "Home");

                // Başarılı JSON yanıtını oluştur
                var successResponse = new
                {
                    success = true,
                    message = "Ödeme işlemi başarıyla tamamlandı."
                };

                // JSON yanıtını döndür
                return Json(successResponse);
            }

            var cart = _cartService.GetCart();

            model.Cart = new CartViewModel
            {
                Items = cart.Items.Select(item => new CartItemViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    UnitPrice = item.UnitPrice,
                    DiscountRate = item.DiscountRate,
                    Quantity = item.Quantity
                }).ToList()
            };

            return View(model);
        }

        public IActionResult RemoveItem(int id)
		{
			_cartService.RemoveFromCart(id);
			return RedirectToAction("Index");
		}

		public IActionResult SetQuantity(int id, int quantity)
		{
			_cartService.SetQuantityCart(id, quantity);
			return RedirectToAction("Index");
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult AddToCart(int productId, int quantity)
		{
			_cartService.AddToCart(productId, quantity);
			var productName = _dbContext.Products.Find(productId).Name;
			return Json(productName);
		}

        [AllowAnonymous]
        public IActionResult ItemCount()
		{
			if (_SignInManager.IsSignedIn(User))
			{
				return Json(_cartService.ItemCount());
			}
			else return Json(0);
		}

	}
}
