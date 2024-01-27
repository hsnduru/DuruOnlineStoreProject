using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities.Identities;
using DuruOnlineStore.WebUI.Services;
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

		[HttpPost]
		public IActionResult AddToCart(int productId)
		{
			_cartService.AddToCart(productId);
			var productName = _dbContext.Products.Find(productId).Name;
			return Json(productName);
		}

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
