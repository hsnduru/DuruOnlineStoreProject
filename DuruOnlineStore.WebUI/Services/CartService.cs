using DuruOnlineStore.Common.Configurations;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace DuruOnlineStore.WebUI.Services
{
	public interface ICartService
	{
		void AddToCart(int productId);
		CartViewModel GetCart();
		int ItemCount();
		void RemoveFromCart(int productId);
		void SetQuantityCart(int productId, int quantity);
	}

	public class CartService : ICartService
	{
		private readonly IProductSearchService _productSearch;
		private readonly DuruStoreContext _dbContext;
		private readonly IUserService _userService;

		public CartService(IProductSearchService productSearch, DuruStoreContext dbContext, IUserService userService)
		{
			_productSearch = productSearch;
			_dbContext = dbContext;
			_userService = userService;
		}

		public CartViewModel GetCart()
		{
			var result = new CartViewModel();
			var productIds = _dbContext.CartItems
				.Where(x => x.AppUserId == _userService.GetUserId())
				.Select(b => b.ProductId).ToList();
			if (productIds == null)
				return result;

			var products = from cart in _dbContext.CartItems.Include(x => x.Product)
				 .Include(x => x.Product.Campaign)
						where
						cart.AppUserId == _userService.GetUserId()
						orderby cart.Product.Name
						select new CartItemViewModel()
						{
							Id = cart.Product.Id,
							Quatitiy = cart.Quantity,
							Name = cart.Product.Name,
							ImageUrl = MyApplicationConfig.ImageBaseUrl + cart.Product.ImageName,
							UnitPrice = cart.Product.Price,
							DiscountRate = cart.Product.Campaign.DiscountRate,
						};
			result.Items = products.ToList();
			return result;
		}

		public void AddToCart(int productId)
		{
			var cartItem = _dbContext.CartItems.FirstOrDefault(x => x.AppUserId == _userService.GetUserId() && x.ProductId == productId);
			if (cartItem != null)
			{
				cartItem.Quantity++;
			}
			else
			{
				var newCartItem = new CartItem { AppUserId = _userService.GetUserId(), ProductId = productId };
				_dbContext.Add(newCartItem);

			}
			_dbContext.SaveChanges();
		}

		public void RemoveFromCart(int productId)
		{
			var cartItem = _dbContext.CartItems.FirstOrDefault(x => x.AppUserId == _userService.GetUserId() && x.ProductId == productId);
			if (cartItem != null)
			{
				_dbContext.Remove(cartItem);
			}
			_dbContext.SaveChanges();
		}

		public void SetQuantityCart(int productId, int quantity)
		{
			if (quantity == 0)
			{
				RemoveFromCart(productId);
			}
			else
			{
				var cartItem = _dbContext.CartItems.FirstOrDefault(x => x.AppUserId == _userService.GetUserId() && x.ProductId == productId);
				if (cartItem != null)
				{
					cartItem.Quantity = quantity;
				}
				_dbContext.SaveChanges();
			}
		}

		public int ItemCount()
		{
			return _dbContext.CartItems
				.Where(it => it.AppUserId == _userService.GetUserId())
				.Sum(x => x.Quantity);

		}
	}
}
