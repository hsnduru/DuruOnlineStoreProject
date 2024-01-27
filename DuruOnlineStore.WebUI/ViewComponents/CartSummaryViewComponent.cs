using DuruOnlineStore.Data.Context;
using DuruOnlineStore.WebUI.Models;
using DuruOnlineStore.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuruOnlineStore.WebUI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartService _cartService;

        public CartSummaryViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cartViewModel = _cartService.GetCart();

            return View(cartViewModel);
        }
    }
}
