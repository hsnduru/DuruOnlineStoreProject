using Microsoft.AspNetCore.Mvc;

namespace DuruOnlineStore.WebUI.Controllers
{
    public class PaymentsController : Controller
    {
		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ProcessPayment()
		{
			return View("ThankYou");
		}
	}
}
